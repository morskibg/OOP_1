using System.Collections.Generic;

public interface ISoldier
{
    string FirstName { get; }
    string LastName { get; }
    string Id { get; }
    void ToString();
}

public interface IPrivate : ISoldier
{
    double Salary { get; }

}

public interface ILtGeneral : ISoldier
{
    HashSet<IPrivate> Privets { get; }
}

public interface ISpecialSoldier : ISoldier
{
    string Corps { get; }
}

public interface IEngineer : ISpecialSoldier
{
    HashSet<KeyValuePair<string, int>> RepeairsData { get; }
}

public interface ICommando : ISpecialSoldier
{
    HashSet<KeyValuePair<string, string>> MissionData { get; }
    void CompleteMission();
}

public interface ISpy : ISoldier
{
    string CodeNumber { get; }
}
