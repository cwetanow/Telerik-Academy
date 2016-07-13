using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract
{
    public abstract class Transmission : TunningPart, ITransmission
    {
        public Transmission(int weight, decimal price, int topSpeed, int acceleration, TunningGradeType type, TransmissionType transmissionType)
            : base(weight, price, topSpeed, acceleration, type)
        {
            this.TransmissionType = transmissionType;
        }

        public TransmissionType TransmissionType
        {
            get; protected set;
        }
    }
}
