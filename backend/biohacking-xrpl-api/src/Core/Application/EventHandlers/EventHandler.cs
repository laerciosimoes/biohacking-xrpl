namespace Application.EventHandlers;
public class EventHandler : IEventHandler
{
    public EventHandler(IHandler handler)
    {
        handler.Add<CreatePatient, CreatePatientEventHandler>();
        handler.Add<DeletePatient, DeletePatientEventHandler>();
        handler.Add<PatientCreated, PatientCreatedEventHandler>();
        handler.Add<PatientDeleted, PatientDeletedEventHandler>();
        handler.Add<PatientGetByID, PatientGetByIDEventHandler>();
        handler.Add<PatientGet, PatientGetEventHandler>();
        handler.Add<PatientUpdated, PatientUpdatedEventHandler>();
        handler.Add<UpdatePatient, UpdatePatientEventHandler>();
    }
}