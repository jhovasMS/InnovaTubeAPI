using InnovaTubeAPI.Datos;
using InnovaTubeAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InnovaTubeAPI.Controllers
{
    [Route("api/videosfavoritos")]
    public class VideosFavoritosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public VideosFavoritosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<VideoFavorito>> Get()
        {
            return await context.VideosFavoritos.ToListAsync();
        }

        [HttpGet("{idVideoYouTube}")]
        public async Task<ActionResult<Boolean>> Get([FromRoute] string idVideoYouTube)
        {
            var videoFavorito = await context.VideosFavoritos.FirstOrDefaultAsync(x => x.IdVideoYouTube == idVideoYouTube);
            if(videoFavorito is null)
            {
                return false;
            }
            return true;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VideoFavorito videoFavorito)
        {
            context.Add(videoFavorito);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{idVideoYouTube}")]
        public async Task<ActionResult> Delete([FromRoute] string idVideoYouTube)
        {
            var filasBorradas = await context.VideosFavoritos.Where(x => x.IdVideoYouTube == idVideoYouTube).ExecuteDeleteAsync();
            if (filasBorradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
