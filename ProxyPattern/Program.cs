using System;

namespace DesignPatterns.Proxy.Conceptual
{
    // Giao diện Subject  khai báo các hoạt động chung cho cả RealSubject và Proxy.
    // Miễn là client làm việc với RealSubject bằng giao diện này, bạn sẽ có thể 
    // chuyển nó qua proxy thay vì chủ thể thực.
    public interface ISubject
    {
        void Request();
    }

    // RealSubject chứa một số logic cốt lõi. Thông thường, RealSubject có khả năng 
    // thực hiện một số công việc hữu ích cũng có thể rất chậm hoặc nhạy cảm - ví dụ: 
    // hiệu chỉnh dữ liệu đầu vào. Proxy có thể giải quyết những vấn đề này mà không 
    // cần bất kỳ thay đổi nào đối với mã của RealSubject.
    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    // Proxy có giao diện giống với RealSubject.
    class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }

        // Các ứng dụng phổ biến nhất của mẫu Proxy là tải chậm, bộ nhớ đệm, kiểm 
        // soát truy cập, ghi nhật ký, v.v. Một Proxy có thể thực hiện một trong những 
        // điều này và sau đó, tùy thuộc vào kết quả, chuyển việc thực thi đến cùng 
        // một phương thức trong một đối tượng RealSubject được liên kết.
        public void Request()
        {
            if (this.CheckAccess())
            {
                this._realSubject.Request();

                this.LogAccess();
            }
        }

        public bool CheckAccess()
        {
            // Một số kiểm tra thực sự nên ở đây.
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }

    public class Client
    {
        // Mã client phải hoạt động với tất cả các đối tượng (cả đối tượng và proxy) 
        // thông qua Subject để hỗ trợ cả đối tượng thực và proxy. Tuy nhiên, trong 
        // cuộc sống thực, client chủ yếu làm việc trực tiếp với đối tượng thực của 
        // nó. Trong trường hợp này, để triển khai mẫu dễ dàng hơn, bạn có thể
        //  mở rộng proxy của mình từ lớp của chủ thể thực.
        public void ClientCode(ISubject subject)
        {
            // ...

            subject.Request();

            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }
}