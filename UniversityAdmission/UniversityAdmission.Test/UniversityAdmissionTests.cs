namespace UniversityAdmission.Test;

public class UniversityAdmissionTests
{
    private readonly UniversityAdmissionFixture _data = new UniversityAdmissionFixture();


    [Fact]
    public void TestGetApplicantFromCity()
    {
        var city = "Самара";
        var reques = (from applicant in _data.Applicants
                      where applicant.City == city
                      select applicant);
        Assert.Equal(2, reques.Count());
    }
}
