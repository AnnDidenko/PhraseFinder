using RestEase;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    [BasePath("ted.com")]
    public interface ITEDApi
    {
        [Get("talks")]
        Task<string> GetListOfVideosHtml([Query] int page);


        [Get("{path}/transcript")]
        Task<string> GetVideoTranscriptHtml([Path] string path, [Query] string language);
    }
}
