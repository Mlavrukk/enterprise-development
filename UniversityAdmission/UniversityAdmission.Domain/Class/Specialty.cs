namespace UniversityAdmission.Domain.Class;

/// <summary>
/// �������������
/// </summary>
public class Specialty
{
    /// <summary>
    /// ������������� �������������
    /// </summary>
    public required int IdSpecialty { get; set; }
    /// <summary>
    /// ���� �������������
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// �������� �������������
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// ���������
    /// </summary>
    public required string Faculty { get; set; }
}