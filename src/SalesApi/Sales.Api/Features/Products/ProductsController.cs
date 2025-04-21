using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Products.CreateProduct;
using Sales.Application.Products.DeleteProduct;
using Sales.Application.Products.GetProduct;
using Sales.Application.Products.GetProducts;
using Sales.Application.Products.UpdateProduct;
using Sales.Api.Common;
using Sales.Api.Products.CreateProducts;
using Sales.Api.Products.DeleteProducts;
using Sales.Api.Products.GetProduct;
using Sales.Api.Products.GetProducts;
using Sales.Api.Products.UpdateProducts;

namespace Sales.Api.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProducts([FromBody] CreateProductsRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductsCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateProductsResponse>
        {
            Success = true,
            Message = "User created successfully",
            Data = _mapper.Map<CreateProductsResponse>(response)
        });
    }

    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdatePorductsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductsRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateProductsCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdatePorductsResponse>
        {
            Success = true,
            Message = "Update Product successfully",
            Data = _mapper.Map<UpdatePorductsResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest(Id: id);
        var validator = new GetProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "User retrieved successfully",
            Data = _mapper.Map<GetProductResponse>(response)
        });
    }

    [HttpGet("All")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var request = new GetProductsRequest { };
        var validator = new GetProductsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetProductsCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetProductsResponse>
        {
            Success = true,
            Message = "Products successfully",
            Data = _mapper.Map<GetProductsResponse>(response)
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProducts([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductsRequest { Id = id };
        var validator = new DeleteProductsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteProductsCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "User deleted successfully"
        });
    }
}
