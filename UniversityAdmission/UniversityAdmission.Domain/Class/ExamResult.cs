namespace UniversityAdmission.Domain.Class;

/// <summary>
/// ��������� �������� �����������
/// </summary>
public class ExamResult
{
    /// <summary>
    /// ������������� ����������
    /// </summary>
    public required int IdExamResult { get; set; }

    /// <summary>
    /// ������������� �����������
    /// </summary>
    public required int ApplicantId { get; set; }

    /// <summary>
    /// ������������� ��������
    /// </summary>
    public required int ExamId  { get; set; }

    /// <summary>
    /// ����� ����������� �� ��������
    /// </summary>
    public required double Score { get; set; }
}