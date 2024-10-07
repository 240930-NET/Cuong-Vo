namespace SalonSystem.APP.Salons;
using SalonSystem.APP.Services;
using SalonSystem.APP.Technicians;
using SalonSystem.APP.WorkingHours;

public class Salon {
    // Static field to keep track of the last used ID
    private static int _idCounter = 1;
    private int _technicianIDCounter; 
    public List<Technician> TechnicianList {get;set;}
    public List<Service> ServiceList {get;set;}
    public int ID{get; private set;}
    public string Name {get;set;}
    public Dictionary<DayOfWeek, WorkingHours> WeeklyWorkingHours { get; set; }

    //Constructor with only name
    public Salon(string name) {
        ID = _idCounter++;
        Name = name;
        _technicianIDCounter = 1;
        WeeklyWorkingHours = new Dictionary<DayOfWeek, WorkingHours>();
        TechnicianList = new List<Technician>();
        ServiceList = new List<Service>();
    }

    public void AddService(Service newService) {
        ServiceList.Add(newService);
    }

    public void AddTechnician(Technician technician)
    {
        technician.ID = _technicianIDCounter++;
        TechnicianList.Add(technician);
    }

    public Service? findServiceByName(string name) {
        foreach (Service service in ServiceList) {
            if (service.Name == name) return service;
        }
        return null; 
    }

    public List<Technician> FindTechnicianToPerform(Service service) 
    {
        List<Technician> qualifiedTechnicians = new List<Technician>();
        foreach (Technician technician in TechnicianList) {
            if (service.CanBePerformedBy(technician)) {
                qualifiedTechnicians.Add(technician);
            }
        }
        return qualifiedTechnicians;
    }

    public void AddTechnician(string name, int salary, PayPeriod payPeriodType = PayPeriod.Weekly) {
        TechnicianList.Add(new Technician(_technicianIDCounter++,name,salary,payPeriodType));
    }

    public void AddService(string name, int duration = -1) => ServiceList.Add(new Service(name));
    //Set Working Hour for the salon.
    public void SetWorkingHours(DayOfWeek day, TimeSpan openingTime, TimeSpan closingTime)
    {
        WeeklyWorkingHours[day] = new WorkingHours(openingTime, closingTime);
    }

    //check if the name salon is open at the specific time.
    public bool isOpen(DayOfWeek day, TimeSpan time) 
    {
        if (WeeklyWorkingHours.ContainsKey(day)) {
            var hours = WeeklyWorkingHours[day];
            return time >=hours.OpeningTime && time <= hours.ClosingTime;
        }
        return false;
    }
    // check if the salon is open on a day of the week.
    public bool boolisOpenOnDay(DayOfWeek day) 
    {
        if (WeeklyWorkingHours.ContainsKey(day)) return true;
        return false;
    }

    

}

