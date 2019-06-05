using DomainModel.DomainClasses;

namespace DomainModel.CQRS.Services
{
    public interface ISalvaDomanda
    {
        void Save(Domanda domanda);
    }
}