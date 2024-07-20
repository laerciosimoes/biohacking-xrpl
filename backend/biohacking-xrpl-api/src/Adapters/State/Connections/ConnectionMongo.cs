namespace DevPrime.State.Connections;
public class ConnectionMongo : MongoBaseState
{
    public ConnectionMongo(MongoBaseState stateContext, IDpState dp) : base(stateContext, dp)
    {
    }
    public IMongoCollection<DevPrime.State.Repositories.Patient.Model.Patient> Patient
    {
        get
        {
            return Db.GetCollection<DevPrime.State.Repositories.Patient.Model.Patient>("Patient");
        }
    }
}