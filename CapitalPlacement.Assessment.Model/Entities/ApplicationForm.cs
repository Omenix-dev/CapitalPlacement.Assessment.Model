
namespace CapitalPlacement.Assessment.Model.Entities
{
    public class ApplicationForm
    {
        public string ImageUrl { get; set; }
        public PersonalInfo personalInfo { get; set; }
    }
    public class PersonalInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ValueObj PhoneObj { get; set; }
        public ValueObj NationalityObj { get; set; }
        public ValueObj CurrentResidenceObj { get; set; }
        public ValueObj IDNumberObj { get; set; }
        public ValueObj DOBObj { get; set; }
        public ValueObj GenderObj { get; set; }
        public List<AdditionalQuestion> MyProperty { get; set; }
        public List<Profile> Profiles { get; set; }
    }
    public class Profile
    {
        public ProfileEducationObject Education { get; set; }
        public ProfileExperienceObject Experience { get; set; }
    }
    public class ProfileEducationObject : ProfileObject
    {
        public List<Education> Education {  get; set; } 
    }
    
    public class ProfileExperienceObject : ProfileObject
    {
        public List<Experience> Experiences { get; set; }
    }
    
    public class ProfileObject
    {
        public bool Mandatory { get; set; }
        public bool Show { get; set; }
        
    }
    
    public class ValueObj
    {
        public bool IsInternal { get; set; }
        public bool IsHidden { get; set; }
        public object Value { get; set; }
    }
}
