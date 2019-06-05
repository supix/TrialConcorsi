using DomainModel.CQRS.Services;
using DomainModel.DomainClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;

namespace Persistence.MongoDB
{
    public class SalvaDomanda : ISalvaDomanda
    {
        public void Save(Domanda domanda)
        {
            BsonClassMap.RegisterClassMap<Domanda>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
            });

            var client = new MongoClient();
            var database = client.GetDatabase("concorsi");
            var domande = database.GetCollection<Domanda>("domande");

            domande.InsertOne(domanda);
        }
    }
}
