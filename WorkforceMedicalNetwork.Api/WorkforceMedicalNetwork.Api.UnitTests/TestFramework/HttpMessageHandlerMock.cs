using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace WorkforceMedicalNetwork.Api.UnitTests.TestFramework
{
    public class HttpMessageHandlerMock
    {
        public HttpStatusCode ReturnStatusCode { get; set; }
        public string ReturnJsonMessage { get; set; }
        public Mock<HttpMessageHandler> Mock { get; set; }

        public HttpMessageHandlerMock()
        {
            Mock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            ReturnStatusCode = HttpStatusCode.OK;
            ReturnJsonMessage = "{\"result\":0}";
            Mock.Protected()
                .Setup<Task<HttpResponseMessage>>
                (
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                // prepare the expected response of the mocked http call
                .ReturnsAsync(() =>
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = ReturnStatusCode,
                        Content = new StringContent(ReturnJsonMessage),
                    };
                })
                .Verifiable();
        }
    }
}