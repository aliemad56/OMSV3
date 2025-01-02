using OMSV1.Domain.Entities.Governorates;
using OMSV1.Domain.Entities.Offices;
using OMSV1.Domain.Entities.Profiles;
using OMSV1.Domain.SeedWork;

namespace OMSV1.Domain.Entities.Lectures;

public class Lecture(string title,
                     DateTime date,
                     string note,
                     Guid officeId,
                     Guid governorateId,
                     Guid profileId) : Entity
{
    public string Title { get; private set; } = title;
    public DateTime Date { get; private set; } = date;
    public string Note { get; private set; } = note;
    public Guid OfficeId { get; private set; } = officeId;
    public Guid GovernorateId { get; private set; } = governorateId;
    public Guid ProfileId { get; private set; } = profileId;
    public Governorate? Governorate { get; private set; }
    public Office? Office { get; private set; }
    public Profile? Profile { get; private set; }

   public void UpdateLectureDetails(string title, DateTime date,string note, Guid officeId, Guid governorateId, Guid profileId)
    {
        Title = title;
        Date = date;
        Note=note;
        OfficeId = officeId;
        GovernorateId = governorateId;
        ProfileId = profileId;
    }



}
