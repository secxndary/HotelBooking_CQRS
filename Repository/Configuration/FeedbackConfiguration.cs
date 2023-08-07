using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasData
        (
            new Feedback
            {
                Id = new Guid("0c4e7c41-7dbe-475f-82ae-4000eb5c4e3d"),
                TextPositive = "Всё очень круто мне все понравилось",
                TextNegative = "Я передумал мне ничего не понравилось",
                ReservationId = new Guid("d013f366-32d2-419b-b413-ee71f557435f")
            },
            new Feedback
            {
                Id = new Guid("3217a198-5a8e-4818-9a7d-786043572775"),
                TextPositive = "Хороший отель интересные конкурсы",
                TextNegative = "Не обнаружено",
                ReservationId = new Guid("0eb13a89-60ee-4d59-b991-908a4412bf0a")
            },
            new Feedback
            {
                Id = new Guid("f0eefc9b-4cbe-4ee7-ae1e-37b335404b72"),
                TextPositive = "Понравилось всё кроме отсутствия завтрака",
                TextNegative = "Перечислены выше",
                ReservationId = new Guid("6a5d35dc-682e-4d02-9e6b-a70550ef9061")
            },
            new Feedback
            {
                Id = new Guid("53032864-6d72-4367-b775-8915a17fb14b"),
                TextPositive = "отсутствует.",
                TextNegative = "всё остальное.",
                ReservationId = new Guid("db277d82-62fd-49b8-b3ed-ad5976c1167c")
            },
            new Feedback
            {
                Id = new Guid("5f0c42ec-4f0b-4d1a-b4d9-8b04513b204f"),
                TextPositive = "Напитки, завтрак в постель, ламинат",
                TextNegative = "Тумба, полка не понравились",
                ReservationId = new Guid("33f113d0-29af-4b2a-ac16-8a8e47aa4fcf")
            },
            new Feedback
            {
                Id = new Guid("2b3b877e-b5c5-4ae8-b336-118492997598"),
                TextPositive = "Консьерж был со мной вежлив",
                TextNegative = "А девушка на ресепшене нет",
                ReservationId = new Guid("ba4a5cf4-fee9-4470-8de1-dd8333e4575d")
            }
        );
    }
}
