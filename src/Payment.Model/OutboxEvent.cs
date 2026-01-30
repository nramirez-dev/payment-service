using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Model
{
    public class OutboxEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Type { get; set; } = default!;

        public string Payload { get; set; } = default!;

        public DateTime OccurredOnUtc { get; set; }

        public DateTime? ProcessedOnUtc { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
