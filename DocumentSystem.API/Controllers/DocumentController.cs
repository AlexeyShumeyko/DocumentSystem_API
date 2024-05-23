using DocumentSystem.Application.Interfaces;
using DocumentSystem.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DocumentEntity>> GetDocuments()
        {
            var documents = _documentService.GetDocuments();

            return documents;
        }

        [HttpGet]
        public async Task<ActionResult<DocumentEntity>> GetDocument(string documentId)
        {
            var document = await _documentService.GetDocumentByIdAsync(documentId);

            if (document == null)
                return NotFound();

            return Ok(document);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentEntity>> CreateDocument(DocumentEntity document)
        {
            var createdDocument = await _documentService.CreateDocumentAsync(document);

            return CreatedAtAction(nameof(GetDocument), new { id = createdDocument.Id }, createdDocument);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDocument(string documentId)
        {
            var result = await _documentService.DeleteDocumentAsync(documentId);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
