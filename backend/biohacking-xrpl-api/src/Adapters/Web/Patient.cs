namespace DevPrime.Web;
public class Patient : Routes
{
    public override void Endpoints(WebApplication app)
    {
        //Automatically returns 404 when no result  
        app.MapGet("/v1/patient", async (HttpContext http, IPatientService Service, int? limit, int? offset, string ordering, string ascdesc, string filter) => await Dp(http).Pipeline(() => Service.GetAll(new Application.Services.Patient.Model.Patient(limit, offset, ordering, ascdesc, filter)), 404));
        //Automatically returns 404 when no result 
        app.MapGet("/v1/patient/{id}", async (HttpContext http, IPatientService Service, Guid id) => await Dp(http).Pipeline(() => Service.Get(new Application.Services.Patient.Model.Patient(id)), 404));
        app.MapPost("/v1/patient", async (HttpContext http, IPatientService Service, DevPrime.Web.Models.Patient.Patient command) => await Dp(http).Pipeline(() => Service.Add(command.ToApplication())));
        app.MapPut("/v1/patient", async (HttpContext http, IPatientService Service, Application.Services.Patient.Model.Patient command) => await Dp(http).Pipeline(() => Service.Update(command)));
        app.MapDelete("/v1/patient/{id}", async (HttpContext http, IPatientService Service, Guid id) => await Dp(http).Pipeline(() => Service.Delete(new Application.Services.Patient.Model.Patient(id))));
    }
}