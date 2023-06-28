using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace FullStack.API.Utilities.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

        }
        protected override bool CanWriteType(Type? type)
        {
            if(typeof(GuestDto).IsAssignableFrom(type)||
                typeof(IEnumerable<GuestDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        private static void FormatCsv(StringBuilder buffer,GuestDto guest)
        {
            buffer.AppendLine($"{guest.Id},{guest.firstName},{guest.surname},{guest.email},{guest.phone}");
        }

        public override async  Task  WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer =  new StringBuilder();

            if(context.Object is IEnumerable<GuestDto>) 
            {
                foreach(var guest in (IEnumerable<GuestDto>)context.Object)
                {
                    FormatCsv(buffer, guest);
                }
            }
            else
            {
                FormatCsv(buffer, (GuestDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
    }
}
