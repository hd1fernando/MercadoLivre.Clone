using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Events;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Users;

namespace MercadoLivre.Clone.Business.CommandHandlers;

// CI: 8
public class ProductQuestionCommandHandler : IRequestHandler<ProductQuestionCommand>
{
    // 5
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUser _loggedUser;
    private readonly IRepository<ProductQuestionEntity, int> _productQuestionRepository;
    private readonly IMediator _mediator;

    public ProductQuestionCommandHandler(IProductRepository productRepository,
        IUserRepository userRepository,
        IUser loggedUser,
        IRepository<ProductQuestionEntity, int> productQuestionRepository,
        IMediator mediator)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        _loggedUser = loggedUser;
        _productQuestionRepository = productQuestionRepository;
        _mediator = mediator;
    }

    // 1
    public async Task<Unit> Handle(ProductQuestionCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByUserEmailAsync(_loggedUser.GetUserEmail(), cancellationToken);
        var product = await _productRepository.FindByIdAsync(request.Productid, cancellationToken);

        // 1
        var productQuestion = new ProductQuestionEntity(request.Title, user, product);

        await _productQuestionRepository.AddAsync(productQuestion, cancellationToken);


        var productOwner = await _userRepository.FindByIdAsync(product.Owner.Id, cancellationToken);
        var mailTo = productOwner.Email;

        // 1
        var mailNotification = new ProductQuestionEvent(mailTo, request.Title);

        await _mediator.Publish(mailNotification, cancellationToken);

        return Unit.Value;
    }
}
