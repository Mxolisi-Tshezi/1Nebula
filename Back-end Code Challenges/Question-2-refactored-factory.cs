// Interfaces to reduce tight coupling
public interface IRobotService
{
    Robot BuildRobotDog(List<Parts> parts);
    Robot BuildRobotCat(List<Parts> parts);
    Robot BuildRobotDrone(List<Parts> parts);
    Robot BuildRobotCar(List<Parts> parts);
}
/// Interface for parts service operations
public interface IPartsService
{
    List<Parts> GetParts(Enum type);
}

//Interface for car service operations

public interface ICarService
{
    Car BuildCar(List<Parts> parts);
}

// Strategy pattern for robot building
public interface IRobotBuildStrategy
{
    Robot Build(IRobotService robotService, List<Parts> parts);
}

public class DogRobotBuildStrategy : IRobotBuildStrategy
{
    public Robot Build(IRobotService robotService, List<Parts> parts)
    {
        return robotService.BuildRobotDog(parts);
    }
}

public class CatRobotBuildStrategy : IRobotBuildStrategy
{
    public Robot Build(IRobotService robotService, List<Parts> parts)
    {
        return robotService.BuildRobotCat(parts);
    }
}

public class DroneRobotBuildStrategy : IRobotBuildStrategy
{
    public Robot Build(IRobotService robotService, List<Parts> parts)
    {
        return robotService.BuildRobotDrone(parts);
    }
}

public class CarRobotBuildStrategy : IRobotBuildStrategy
{
    public Robot Build(IRobotService robotService, List<Parts> parts)
    {
        return robotService.BuildRobotCar(parts);
    }
}

// Refactored Factory class using dependency injection and strategy pattern
public class Factory
{
    private readonly IRobotService _robotService;
    private readonly IPartsService _partsService;
    private readonly ICarService _carService;
    private readonly Dictionary<Enum, IRobotBuildStrategy> _robotBuildStrategies;

    public Factory(IRobotService robotService, IPartsService partsService, ICarService carService)
    {
        _robotService = robotService ?? throw new ArgumentNullException(nameof(robotService));
        _partsService = partsService ?? throw new ArgumentNullException(nameof(partsService));
        _carService = carService ?? throw new ArgumentNullException(nameof(carService));

        // Initialize strategies
        _robotBuildStrategies = new Dictionary<Enum, IRobotBuildStrategy>
        {
            { RobotType.RoboticDog, new DogRobotBuildStrategy() },
            { RobotType.RoboticCat, new CatRobotBuildStrategy() },
            { RobotType.RoboticDrone, new DroneRobotBuildStrategy() },
            { RobotType.RoboticCar, new CarRobotBuildStrategy() }
        };
    }

    public Robot BuildRobot(Enum robotType)
    {
        if (!_robotBuildStrategies.TryGetValue(robotType, out var strategy))
        {
            return null;
        }

        var parts = GetRobotPartsFor(robotType);
        return strategy.Build(_robotService, parts);
    }

    /// Builds a car of the specified type

    public Car BuildCar(Enum carType)
    {
        if (!Enum.IsDefined(typeof(CarType), carType))
        {
            return null;
        }

        var parts = GetCarPartsFor(carType);
        return _carService.BuildCar(parts);
    }

    /// Gets parts for building a robot

    public List<Parts> GetRobotPartsFor(Enum robotType)
    {
        return _partsService.GetParts(robotType);
    }

    /// Gets parts for building a car

    public List<Parts> GetCarPartsFor(Enum carType)
    {
        return _partsService.GetParts(carType);
    }
}

// Enum definitions
public enum RobotType
{
    RoboticDog,
    RoboticCat,
    RoboticDrone,
    RoboticCar
}

public enum CarType
{
    Toyota,
    Ford,
    Opel,
    Honda
}