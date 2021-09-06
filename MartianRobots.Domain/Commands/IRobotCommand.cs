using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.Commands
{
    public interface IRobotCommand
    {
        void Execute(Robot robot);
    }
}
