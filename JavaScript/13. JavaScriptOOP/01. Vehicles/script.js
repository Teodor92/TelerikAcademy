// Note: See here for enums in JavaScript: http://stackoverflow.com/a/5040502
// enums
var afterBurnerStateEnum = Object.freeze({'On': 1, 'Off': 2});

var AmphibiousVehicleStateEnum = Object.freeze({ 'Land': 1, 'Water': 2 });

var SpinDirectionEnum = Object.freeze({'Clockwise': 1, 'Conter-clockwise': 2});

// helerp funcs
Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

// Propolltion units
function Wheel(radius) {
    this.Radius = radius;
}

Wheel.prototype.getAcceleration = function () {
    return 2 * Math.PI * this.Radius;
};

function PropellingNozzle(power, afterBurnerState) {
    this.Power = power;
    this.AfterBurnerState = afterBurnerState;
}

PropellingNozzle.prototype.getAcceleration = function () {
    if (this.AfterBurnerState === afterBurnerStateEnum.On) {
        return this.Power * 2;
    } else {
        return this.Power;
    }
};

function Propeller(numberOfFins, spinDirection) {
    this.NumberOfFins = numberOfFins;
    this.SpinDirection = spinDirection;
}

Propeller.prototype.getAcceleration = function () {
    if (this.SpinDirection === SpinDirectionEnum.Clockwise) {
        return this.NumberOfFins;
    } else {
        return (-1) * (this.NumberOfFins);
    }
};

// Base vehicle class
function Vehicle(speed, propoltionUnit) {
    this.Speed = speed;
    this.PropoltionUnit = propoltionUnit;
}

Vehicle.prototype.Accelerate = function () {
    var i;

    if (this.PropoltionUnit instanceof Array) {
        for (i in this.PropoltionUnit) {
            this.Speed += this.PropoltionUnit[i].getAcceleration();
        }
    } else {
        this.Speed += this.PropoltionUnit.getAcceleration();
    }
};

// Land vehicle
function LandVehicle() {
    this.Speed = 0;
    this.PropoltionUnit = [new Wheel(4), new Wheel(4), new Wheel(4), new Wheel(4)];
}

LandVehicle.inherit(Vehicle);

// Water vehicle
function WaterVehicle(propellers) {
    this.Speed = 0;
    this.PropoltionUnit = propellers;
}

WaterVehicle.inherit(Vehicle);

WaterVehicle.prototype.ChangePropelerSpinToClockwise = function () {
    var i;

    if (this.PropoltionUnit instanceof Array) {
        for (i = 0; i < this.PropoltionUnit.length; i++) {
            this.PropoltionUnit[i].SpinDirection = true;
        }
    } else {
        this.PropoltionUnit.SpinDirection = false;
    }
};

WaterVehicle.prototype.ChangePropelerSpinToConterClockwise = function () {
    var i;

    if (this.PropoltionUnit instanceof Array) {
        for (i = 0; i < this.PropoltionUnit.length; i++) {
            this.PropoltionUnit[i].SpinDirection = false;
        }
    } else {
        this.PropoltionUnit.SpinDirection = false;
    }
};

// Air vehicle
function AirVehicle() {
    this.Speed = 0;
    this.PropoltionUnit = new PropellingNozzle(200, true);
}

AirVehicle.inherit(Vehicle);

AirVehicle.prototype.turnOnAfterburner = function () {
    this.PropoltionUnit.AfterBurnerState = afterBurnerStateEnum.On;
};

AirVehicle.prototype.turnOffAfterburner = function () {
    this.PropoltionUnit.AfterBurnerState = afterBurnerStateEnum.Off;
};

// Amphibious vehicle
function AmphibiousVehicle(startMode) {
    this.Speed = 0;
    if (startMode === AmphibiousVehicleState.Land) {
        this.PropoltionUnit = [
            new Propeller(4, SpinDirectionEnum.Clockwise),
            new Propeller(4, SpinDirectionEnum.Clockwise),
            new Propeller(4, SpinDirectionEnum.Clockwise)];
    } else if (startMode === AmphibiousVehicleStateEnum.Water) {
        this.PropoltionUnit = [
            new Wheel(4),
            new Wheel(4),
            new Wheel(4),
            new Wheel(4)];
    }
}

AmphibiousVehicle.inherit(Vehicle);

// tests
var wheelTest = new Wheel(20);
console.log(wheelTest.getAcceleration());

var propelerTest = new PropellingNozzle(200, afterBurnerStateEnum.On);
console.log(propelerTest.getAcceleration());

var propTest = new Propeller(20, afterBurnerStateEnum.Off);
console.log(propTest.getAcceleration());

var landTest = new LandVehicle();
console.log(landTest.Speed);
landTest.Accelerate();
console.log(landTest.Speed);

console.log('Water');
var waterTest = new WaterVehicle([
    new Propeller(4, SpinDirectionEnum.Clockwise),
    new Propeller(4, SpinDirectionEnum.Clockwise),
    new Propeller(4, SpinDirectionEnum.Clockwise)]);

console.log(waterTest.Speed);
waterTest.Accelerate();
console.log(waterTest.Speed);
waterTest.ChangePropelerSpinToConterClockwise();
waterTest.Accelerate();
console.log(waterTest.Speed);

console.log('Air');
var airTest = new AirVehicle();
console.log(airTest.Speed);
airTest.Accelerate();
console.log(airTest.Speed);
airTest.turnOnAfterburner();
airTest.Accelerate();
console.log(airTest.Speed);