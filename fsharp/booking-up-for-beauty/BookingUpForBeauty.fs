module BookingUpForBeauty

open System

let schedule (appointmentDateDescription: string): DateTime =
    DateTime.Parse(appointmentDateDescription)

let hasPassed (appointmentDate: DateTime): bool =
    appointmentDate < DateTime.Now

let isAfternoonAppointment (appointmentDate: DateTime): bool =
    appointmentDate.Hour >= 12 && appointmentDate.Hour < 18

let description (appointmentDate: DateTime): string =
    sprintf "You have an appointment on %s." (appointmentDate.ToString("M/d/yyyy h:mm:ss tt"))

let anniversaryDate(): DateTime =
    new DateTime(2024, 9, 15, 0, 0, 0)
