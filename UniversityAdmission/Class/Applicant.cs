namespace UniversityAdmission.Domain.Class;

/// <summary>
/// ����������
/// </summary>]
public class Applicant
{
    /// <summary>
    /// ������������� �����������
    /// </summary>
    public required int IdApplicant { get; set; }

    /// <summary>
    /// ��� �����������
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// ���� �������� �����������
    /// </summary>
    public required DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// ������ �����������
    /// </summary>
    public required string Country { get; set; }

    /// <summary>
    /// ����� �����������
    /// </summary>
    public required string City { get; set; }
}