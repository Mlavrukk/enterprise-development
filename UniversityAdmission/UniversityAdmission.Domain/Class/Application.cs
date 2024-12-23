namespace UniversityAdmission.Domain.Class;

/// <summary>
/// ��������� ����������� �� �������������
/// </summary>
public class Application
{
    /// <summary>
    /// ������������� ���������
    /// </summary>
    public required int IdApplication { get; set; }

    /// <summary>
    /// ������������� �����������
    /// </summary>
    public required int ApplicantId { get; set; }

    /// <summary>
    /// ������������� �������������
    /// </summary>
    public required int SpecialtyId { get; set; }

    /// <summary>
    /// ��������� �������������
    /// </summary>
    public required int Priority { get; set; }
}