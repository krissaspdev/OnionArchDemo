using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        private ISet<PassengerNode> _passtngerNodes = new HashSet<PassengerNode>();
        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }

        public IEnumerable<PassengerNode> PassengerNodes => _passtngerNodes;


        public DailyRoute()
        {
            Id = Guid.NewGuid();
        }
        public void AddPassengerNode(Passenger passenger, Node node)
        {
            var passengerNode = GetPassengerNode(passenger);
            if (passenger != null)
            {
                throw new InvalidOperationException($"Node already exist for passenger {passenger.UserId}.");
            }

            _passtngerNodes.Add(PassengerNode.Create(passenger, node));
        }

        public void RemovePassengerNode(Passenger passenger)
        {
            var passengerNode = GetPassengerNode(passenger);
            if (passenger == null)
            {
                return;
            }

            _passtngerNodes.Remove(passengerNode);
        }

        private PassengerNode GetPassengerNode(Passenger passenger)
        => _passtngerNodes.SingleOrDefault(x => x.Passenger.UserId == passenger.UserId);
    }
}