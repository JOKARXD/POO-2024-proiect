using System;
using System.Collections.Generic;
using System.Linq;

namespace RezervareProject
{
    // ---------------------
    // USER BASE CLASS
    // ---------------------
    public class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        // Each user can see their own reservations
        public List<Reservation> Reservations { get; } = new List<Reservation>();

        public User(string name)
        {
            Name = name;
        }

        // By default, a regular user cannot edit/cancel others' reservations
        public virtual bool CanEditOthersReservations(User targetUser) => false;
    }

    // ---------------------
    // MANAGER
    // ---------------------
    public class Manager : User
    {
        // A manager has a team of employees
        public List<User> Team { get; } = new List<User>();

        public Manager(string name) : base(name)
        {
        }

        /// <summary>
        /// Manager can edit/cancel reservations if:
        /// - The reservation belongs to themselves (the manager), OR
        /// - The reservation belongs to someone in their <c>Team</c>.
        /// </summary>
        public override bool CanEditOthersReservations(User targetUser)
        {
            // Manager can always modify their own reservations
            if (targetUser.Id == this.Id)
                return true;

            // Or if the target is in their team
            return Team.Any(member => member.Id == targetUser.Id);
        }
    }

    // ---------------------
    // ADMIN
    // ---------------------
    public class Admin : User
    {
        public Admin(string name) : base(name)
        {
        }

        /// <summary>
        /// Admin can edit/cancel any reservation (for any user).
        /// </summary>
        public override bool CanEditOthersReservations(User targetUser) => true;
    }

    // ---------------------
    // ABSTRACT RESERVATION
    // ---------------------
    public abstract class Reservation
    {
        // A global list to keep track of every reservation
        public static List<Reservation> AllReservations { get; } = new List<Reservation>();

        public Guid Id { get; private set; } = Guid.NewGuid();
        public User ReservedBy { get; private set; }
        public DateTime ReservationDate { get; private set; }

        protected Reservation(User reservedBy)
        {
            ReservedBy = reservedBy;
            ReservationDate = DateTime.Now;

            // Add to global list + user’s own list
            AllReservations.Add(this);
            ReservedBy.Reservations.Add(this);
        }

        // Each derived class prints details in its own way
        public abstract void PrintDetails();

        // Each derived class implements how to cancel and free the resource
        public abstract void CancelReservation(User caller);

        // Protect permission check with a helper
        protected void CheckCallerPermissions(User caller)
        {
            // If the caller didn't create this reservation, check if they have rights
            if (caller.Id != ReservedBy.Id && !caller.CanEditOthersReservations(ReservedBy))
            {
                throw new InvalidOperationException(
                    $"{caller.Name} does not have permission to cancel this reservation of {ReservedBy.Name}.");
            }
        }
    }

    // ---------------------
    // DESK RESERVATION
    // ---------------------
    public class DeskReservation : Reservation
    {
        // "Global" desks
        private static List<int> AllDeskNumbers { get; } = new List<int> { 1, 2, 3 };
        private static HashSet<int> ReservedDeskNumbers { get; } = new HashSet<int>();

        public int DeskNumber { get; private set; }

        public DeskReservation(User reservedBy, int deskNumber)
            : base(reservedBy)
        {
            if (!AllDeskNumbers.Contains(deskNumber))
            {
                throw new ArgumentException($"Desk #{deskNumber} does not exist.");
            }
            if (ReservedDeskNumbers.Contains(deskNumber))
            {
                throw new InvalidOperationException($"Desk #{deskNumber} is already reserved.");
            }

            DeskNumber = deskNumber;
            ReservedDeskNumbers.Add(deskNumber);
        }

        public override void PrintDetails()
        {
            Console.WriteLine(
                $"[DeskReservation] ID={Id}, User={ReservedBy.Name}, Desk={DeskNumber}, Date={ReservationDate}");
        }

        public override void CancelReservation(User caller)
        {
            // 1) Permission check
            CheckCallerPermissions(caller);

            // 2) Free resource
            ReservedDeskNumbers.Remove(DeskNumber);

            // 3) Remove from global list + user’s list
            AllReservations.Remove(this);
            ReservedBy.Reservations.Remove(this);

            Console.WriteLine($"Desk reservation (ID={Id}, Desk={DeskNumber}) canceled by {caller.Name}.");
        }
    }

    // ---------------------
    // PARKING RESERVATION
    // ---------------------
    public class ParkingReservation : Reservation
    {
        private static List<int> AllParkingSpots { get; } = new List<int> { 1, 2, 3 };
        private static HashSet<int> ReservedParkingSpots { get; } = new HashSet<int>();

        public int ParkingSpotNumber { get; private set; }

        public ParkingReservation(User reservedBy, int spotNumber)
            : base(reservedBy)
        {
            if (!AllParkingSpots.Contains(spotNumber))
            {
                throw new ArgumentException($"Parking spot #{spotNumber} does not exist.");
            }
            if (ReservedParkingSpots.Contains(spotNumber))
            {
                throw new InvalidOperationException($"Parking spot #{spotNumber} is already reserved.");
            }

            ParkingSpotNumber = spotNumber;
            ReservedParkingSpots.Add(spotNumber);
        }

        public override void PrintDetails()
        {
            Console.WriteLine(
                $"[ParkingReservation] ID={Id}, User={ReservedBy.Name}, Parking={ParkingSpotNumber}, Date={ReservationDate}");
        }

        public override void CancelReservation(User caller)
        {
            // 1) Permission check
            CheckCallerPermissions(caller);

            // 2) Free resource
            ReservedParkingSpots.Remove(ParkingSpotNumber);

            // 3) Remove from global + user’s list
            AllReservations.Remove(this);
            ReservedBy.Reservations.Remove(this);

            Console.WriteLine($"Parking reservation (ID={Id}, Spot={ParkingSpotNumber}) canceled by {caller.Name}.");
        }
    }

    // ---------------------
    // MAIN PROGRAM
    // ---------------------
    public class Program
    {
        static void Main(string[] args)
        {
            // Create some Users
            var alice = new User("Alice");
            var bob = new Manager("Bob");
            var charlie = new Admin("Charlie");

            // Assign Alice to Bob’s team
            bob.Team.Add(alice);

            // 1) Alice reserves a desk
            try
            {
                var deskAlice = new DeskReservation(alice, 1);
                Console.WriteLine("[SUCCESS] Alice reserved desk #1");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }

            // 2) Bob (manager) reserves parking
            try
            {
                var bobParking = new ParkingReservation(bob, 2);
                Console.WriteLine("[SUCCESS] Bob reserved parking #2");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }

            // 3) Charlie (admin) reserves desk #2
            try
            {
                var charlieDesk = new DeskReservation(charlie, 2);
                Console.WriteLine("[SUCCESS] Charlie reserved desk #2");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }

            // Print all reservations
            Console.WriteLine("\n--- ALL RESERVATIONS ---");
            foreach (var res in Reservation.AllReservations)
            {
                res.PrintDetails();
            }

            // 4) Bob tries to cancel Alice’s reservation (Alice is in Bob's team → allowed)
            var aliceDeskRes = alice.Reservations.FirstOrDefault(r => r is DeskReservation);
            if (aliceDeskRes != null)
            {
                Console.WriteLine("\n--- Bob tries to cancel Alice's desk reservation (Alice is on Bob's Team) ---");
                try
                {
                    aliceDeskRes.CancelReservation(bob);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }
            }

            // Print updated list
            Console.WriteLine("\n--- AFTER BOB CANCELS ALICE’S DESK ---");
            foreach (var res in Reservation.AllReservations)
            {
                res.PrintDetails();
            }

            // 5) For demonstration, let's have Charlie (admin) cancel Bob’s parking
            var bobParkingRes = bob.Reservations.FirstOrDefault(r => r is ParkingReservation);
            if (bobParkingRes != null)
            {
                Console.WriteLine("\n--- Charlie (admin) cancels Bob's parking reservation ---");
                try
                {
                    bobParkingRes.CancelReservation(charlie);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }
            }

            // Print final reservations
            Console.WriteLine("\n--- FINAL RESERVATIONS ---");
            foreach (var res in Reservation.AllReservations)
            {
                res.PrintDetails();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
