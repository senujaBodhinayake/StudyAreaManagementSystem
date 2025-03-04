using StudyAreaManagementSystem.DataStructures;
using StudyAreaManagementSystem.Models;
using System;
using System.Collections.Generic;
class Program
{
    static UserLinkedList students = new UserLinkedList();
    static List<StudyArea> studyAreas = new List<StudyArea>
    {
        new StudyArea(1,"Main Study Area",10),
        new StudyArea(2,"Canteen Upper flow",5)
    };
    static waitingListQueue waitingList = new waitingListQueue();
    static List<Reservation> reservations = new List<Reservation>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==== Study Area Management System ====");
            Console.WriteLine("1.Register as Student");
            Console.WriteLine("2. Reserve a Study Area");
            Console.WriteLine("3. Cancel Reservation");
            Console.WriteLine("4. View Available Study Areas");
            Console.WriteLine("5. View Reserved Seats");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RegisterStudent();
                    break;
                case "2":
                    ReserveSeat();
                    break;
                case "3":
                    CancelReservation();
                    break;
                case "4":
                    DisplayStudyAreas();
                    break;
                case "5":
                    ShowReservations();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();


        }
    }
    static void RegisterStudent()
    {
        Console.Write("Enter Student ID: ");
        int id=int.Parse(Console.ReadLine());
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Student student = new Student(id,name);
        students.Add(student);
        Console.WriteLine("Student registered successfully!");

    }
    static void ReserveSeat()
    {
        Console.Write("Enter Student ID: ");
        int studentId=int.Parse(Console.ReadLine());
        Student student = students.Find(studentId);
        if(student == null)
        {
            Console.WriteLine("student not found!");
            return;
        }
        DisplayStudyAreas();
        Console.Write("Enter Study Area ID: ");
        int areaID=int.Parse(Console.ReadLine());

        StudyArea selectedArea = studyAreas.Find(sa => sa.ID == areaID);
        if(selectedArea == null)
        {
            Console.WriteLine("Invalid study area ID!");
            return;
        }
        if(selectedArea.ReserveSeat(student))
        {
            Console.WriteLine("Seat reserved successfully!");

        }
        else
        {
            Console.WriteLine("Study area full.Adding to waiting list.");
            waitingList.Enqueue(student);
        }
        

    }
    static void CancelReservation()
    {
        Console.Write("Enter student ID to cancel reservation: ");
        int studentId=int.Parse(Console.ReadLine());
        Student student=students.Find(studentId);
        if(student == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }
        foreach(var area in studyAreas)
        {
            if (area.CancelReservation(student))
            {
                Console.WriteLine("Reservation cancelled succesfully!");
                if (waitingList.count > 0)
                {
                    Student nextstudent = waitingList.Dequeue();
                    area.ReserveSeat(nextstudent);
                    Console.WriteLine($"Student {nextstudent.Name}moved from waiting list to the study area.");

                }
                return;
            }
        }
        Console.WriteLine("No active reservation found for this student.");

    }
    static void DisplayStudyAreas()
    {
        Console.WriteLine("==== Study Areas ====");
        foreach (var area in studyAreas)
        {
            Console.WriteLine($"ID: {area.ID} | Name: {area.Name} | Available Seats: {area.AvailableSeats}");
        }
    }
    static void ShowReservations()
    {
        Console.Clear();
        Console.WriteLine("==== Current Reservations ====");
        foreach (var area in studyAreas)
        {
            area.showReservedSeats();
            Console.WriteLine();
        }
    }

}
