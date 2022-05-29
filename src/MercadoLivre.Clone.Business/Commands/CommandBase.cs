using MediatR;

namespace MercadoLivre.Clone.Business.Commands;

public abstract class CommandBase<T> : IRequest<T> { }

public abstract class CommandBase : IRequest { }
