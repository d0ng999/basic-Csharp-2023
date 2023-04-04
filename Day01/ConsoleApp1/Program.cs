using System; // system을 안써도 되게 만들어줌

// namespace ConsoleApp1
namespace ConsoleApp1 // namespace안에 여러개의 class가 들어있다.
{
    /// <summary>
    /// 주석 - 문서화할 때 자동으로 해줌, 프로그램 클래스
    /// </summary>
    internal class Program // private과 비슷 + 클래스명(= 파일명)
    {
        /// <summary>
        /// 메인 엔트리 포인트
        /// </summary>
        /// <param name="args">콘솔 매개변수</param>
        static void Main(string[] args) // 프로그램이 시작하는 시작점
        {
            Console.WriteLine("Hello, World~"); //print와 같은 개념
            //alt enter - content assistant 기능
        }
    }
}
