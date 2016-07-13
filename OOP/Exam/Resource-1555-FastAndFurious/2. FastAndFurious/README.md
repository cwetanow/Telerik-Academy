![logo](https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png)


## Object-Oriented Programming – Practical example - 11 July 2016
## Problem 2 – Fast and Furious

It's a drag race!
Straight to the point:  
You have **race tracks**, **drivers**, **cars**, **tunning parts**, **engines**, Vin Diesel and lots of adrenaline.  
Your main objective is to pick a car, tune it up, and race with other maniacs on the different race tracks.

All **drivers** have **Id**, **Name**, **Gender** and a set of **Vehicles**. They are allowed to drive only one car at a time - this is their **ActiveVehicle**. A driver can **Add** and **Remove** vehicles from his collection, or change his **ActiveVehicle**, but not during a race!  
All **motor vehicles** have **Id**, **Weight**, **Acceleration**, **TopSpeed**, **Price** and a set of **TunningParts**. A vehicle can **Add** and **Remove** tunning parts, but most importantly - a vehicle can **Race**.   

All **tunning parts** have **Id**, **Weight**, **Acceleration**, **TopSpeed**, **Price** and a **GradeType**. Acceleration and TopSpeed in the context of tunning parts, represent the acceleration and top speed **bonus**, that is given to a car, which uses this tunning part. This means, that if we have a car which has for example - TopSpeed of **200 Km/h** , and Acceleration - **15 m/s^2**, and a tunning part which gives **10 Km/h** TopSpeed bonus and **5 m/s^2** Acceleration bonus, this gives the car a **total** of **210 Km/h** TopSpeed, and **20 m/s^2** Acceleration. The **TopSpeed** is always given in **kilometers per hour**, and the **Acceleration** is always given in **meters per second squared**. Consider this in your calculations!

A vehicle can hold **only one type of tunning part**, which means that for example - you **cannot have 2 or more** Turbochargers installed on your car at the same time or **2 or more** Engines.

And for last, we have **Race Tracks** that have **Id**, **TrackName**, **TrackLengthInMeters**, **MaxParticipantsCount**, **MinParticipantsCount**, a set of **Participants** that can compete with each other during a race, and a set of **FinishedRacesResults**, that holds all the records of previous races that were conducted on this race track.

You have a set of **predefined** drivers, race tracks, motor vehicles, and tunning parts.  

_You can choose from the following **driver types** with the described characteristics:_  
The described characteristics are as follows:  
**(type) - (name, gender)**  
**DominicRendeto** - ("Dominic Rendeto", "Male")  
**LetiSpaghetti** - ("Leti Spaghetti", "Female")  
**VinBenzin** - ("Vin Benzin", "Male")  
**Jessi** - ("Jessi", "Female")  
**Vince** - ("Vince", "Male")  
**Mia** - ("Mia", "Female")  

_You can choose from the following **vehicle types** with the described characteristics:_  
The described characteristics are as follows:  
**(type) - (price, weight in grams, top speed, acceleration)**  
**AcuraIntegraTypeR** - ($24999,1700000,200,15)  
**MitsubishiEclipse** - ($29999,1400000,230,24)  
**MitsubishiLancerEvolution** - ($56999,1780000,300,20)  
**Nissan350Z** - ($25999,1280000,220,55)  
**NissanGTR** - ($125000,1850000,300,45)  
**NissanSkylineR34** - ($45999,1850000,280,50)  
**SubaruImprezaWRX** - ($55999,1560000,260,35)  

_You can choose from the following **engine motor types** with the described characteristics:_   
The described characteristics are as follows:  
**(type) - (price, weight in grams, acceleration, top speed, horsepower, tunning grade, cylinder type, motor type)**  
**CentaurPulseMotor** - ($5999,175000, 50, 180, 480, MidGrade, V6, PulseDetonationMotor)   
**HellcatMotor** - ($14599,145000, 75, 250, 760, HighGrade, V16, SabreReactionMotor)   
**IronHorseMotor** - ($6399,180000, 70, 130, 350, MidGrade, V8, SteamMotor)   
**ShockblazePulsejetMotor** - ($12899,150000, 80, 220, 700, HighGrade, V16, PulseJet)   
**StingrayMotor** - ($10899,158000, 60, 230, 800, HighGrade, V12, ReciprocatingMotor)   
**TyphoonPulseMotor** - ($15999,176000, 90, 300, 1200, HighGrade, V16, PulseDetonationMotor)   

_You can choose from the following **engine control unit types** with the described characteristics:_   
The described characteristics are as follows:  
**(type) - (price, weight in grams, acceleration bonus, top speed bonus, tunning grade, engine control unit type)**  
**APREngineControlUnit** - ($5789, 22000, 45, 180, HighGrade, Pro)   
**DinanEngineControlUnit** - ($4999, 19000, 35, 65, MidGrade, Performance)   
**SCTPerformanceEngineControlUnit** - ($3599, 21000, 25, 45, LowGrade, Stock)   

_You can choose from the following **exhaust system types** with the described characteristics:_   
The described characteristics are as follows:  
**(type) - (price, weight in grams, acceleration bonus, top speed bonus, tunning grade, exhaust type)**  
**BorlaExhaust** - ($1299, 14600, 12, 40, HighGrade, CeramicCoated)   
**RemusExhaust** - ($679, 11500, 8, 32, MidGrade, StainlessSteel)   
**MagnaflowExhaust** - ($379, 12800, 5, 25, LowGrade, NickelChromePlated)   

_You can choose from the following **turbocharger types** with the described characteristics:_   
The described characteristics are as follows:  
**(type) - (price, weight in grams, acceleration bonus, top speed bonus, tunning grade, turbocharger type)**  
**VortexR35SequentialTurbocharger** - ($699, 3900, 10, 85, HighGrade, SequentialTurbo)   
**ZX8ParallelTwinTurbocharger** - ($799, 3500, 15, 60, HighGrade, TwinTurbo)   

_You can choose from the following **intercooler types** with the described characteristics:_   
The described characteristics are as follows:  
**(type) - (price, weight in grams, acceleration bonus, top speed bonus, tunning grade, intercooler type)**  
**EvolutionXPerformanceIntercooler** - ($499, 4500, -5, 40, HighGrade, AirToLiquidIntercooler)   
**ViperGenieIntercooler** - ($289, 5300, 0, 25, MidGrade, ChargeAirIntercooler)   

_You can choose from the following **transmission types** with the described characteristics:_   
The described characteristics are as follows:  
**(type) - (price, weight in grams, acceleration bonus, top speed bonus, tunning grade, transmission type)**  
**BMShortShifter** - ($2799, 5700, 28, 0, HighGrade, ManualShortShifter)   
**HurstCompetitionManualShifter** - ($1999, 6000, 20, 0, MidGrade, StockShifter)   
**TWMPerformanceTransmission** - ($1599, 4799, 15, 0, LowGrade, SemiManualShifter)   

_You can choose from the following **tire set types** with the described characteristics:_   
The described characteristics are as follows:  
**(type) - (price, weight in grams, acceleration bonus, top speed bonus, tunning grade, tire type)**  
**FalkenAzenisTiresSet** - ($359, 7800, 3, 0, LowGrade, OffRoadTire)   
**YokohamaAdvanTiresSet** - ($589, 6600, 5, 1, MidGrade, AllTerrainTire)  
**MichelinPilotTiresSet** - ($1399, 6500, 7, 1, HighGrade, PerformanceTire)   

_You can choose from the following **race track types** with the described characteristics:_  
The described characteristics are as follows:  
**(type) - (track name, max participants count, min participants count, track length in meters)**  
**IndianapolisRaceTrack** - ("Indianapolis Race Track", 7, 2, 12000)   
**MonacoRaceTrack** - ("Monaco Race Track", 5, 2, 2000)   
**StormblazeRaceTrack** - ("Stormblaze Race Track", 4, 2, 1000)   
**TokioUndergroundRaceTrack** - ("Tokio Underground Race Track", 8, 2, 5000)   

Since you **cannot add more than 1 type of tunning part per car**, you should make use of the partially implemented class **TunningDuplicationException** that can be found inside the solution.  

The **engine** that runs the application, must support the following **COMMANDS**:  
-create -driver (driverTypeName)  
-create -vehicle (vehicleTypeName)  
-create -tunning (tunningTypeName)  
-assign -tunning (tunningPartId) to -vehicle (vehicleId)  
-assign -vehicle (vehicleId) to -driver (driverId)  
-assign -driver (driverId) to -track (trackId)  
-remove -tunning (tunningPartId) from -vehicle (vehicleId)  
-remove -vehicle (vehicleId) from -driver (driverId)  
-remove -driver (driverId) from -track (trackId)  
-select -vehicle (vehicleId) for -driver (driverId) **(Changes the ActiveVehicle of the selected driver, so that he can use it for Racing)**  
-run -track (trackId) **(Prepares the signed participants for racing, calculates the time required for each driver to finish the Race Track, and saves the results in the Race Track history)**  
-display best (timesCount) times from -track (trackId) **(Displays the fastest N times from the Race Track all time history records)**  
-exit **(Terminates the program execution)**  

Some of the commands are already implemented and working. Your task is to figure out what is currently missing in the Application Engine and implement it. Look out for hints.  

All types created are stored in the Engine. The Engine knows it all.

Keep in mind that you must clear the participants from the Racing Track after every competition. Otherwise you will experience strange behavior. I guess you already figured out that you **should not be able to sign the same participant for a single race more than once**. Throw some **InvalidOperationException()** when you meet such a faulty condition. Check the sample input/output cases to find out which are the proper messages to be printed.  

If no races occured on a Racing Track which is requested to display the best times - Output - **"No races yet for {RaceTrackName}"**. If you are required to display, for example - best 3 times, but there are only 2 results in the history of the Racing Track - display the available 2 results.

### Design the Class Hierarchy
Your task is to design an object-oriented class hierarchy to model the Fast and Furious Drag Racing System, using the best practices for object-oriented design (OOD) and object-oriented programming (OOP). Avoid duplicated code through abstraction, inheritance, and polymorphism and encapsulate correctly all fields.

**You are given a set of predefined interfaces in the project skeleton. Analyze them properly, check again the described types requirements. Try to find similarities between the objects, extract new interfaces if necessary and extract base classes that implement the proper interfaces, to prevent repeating code. Do it only where it makes sense to do so.**  

### Additional Notes
For the purpose of simplifying your work - you are given a set of **Utility** classes, such as **DataGenerator, MetricUnitsConverter, TypeCaster**, etc. Check them carefully and use them everywhere you find suitable.  
You are also given a class with extension methods, which you might find useful and which you can extend if necessary.  
There are some enumerations and constants that might help you make your code cleaner and more manageable. You are allowed to extend them or create entirely new ones that fulfill your requirements.

You are **allowed to add new classes, interfaces, enums, etc**. You are **also allowed** to modify the existing types **where marked explicitly as "modifiable"** with the comment **// TODO: Implement**. You are **not allowed** to modify existing types, that are not marked as _"modifiable"_.

_**HINT 1: Examine the sample input and output cases for more clear and concise understanding for the required functionalities.**_
_**HINT 2: Examine the existing classes, interfaces and other types. Analyze the existing functionality. Learn how to steal code and adapt it to your needs.**_

### Sample Input
```
-create -driver VinBenzin
-create -vehicle MitsubishiLancerEvolution
-assign -vehicle 2 to -driver 1
-create -tunning VortexR35SequentialTurbocharger
-create -tunning EvolutionXPerformanceIntercooler
-create -tunning BMShortShifter
-create -tunning MichelinPilotTiresSet
-create -tunning BorlaExhaust
-create -tunning APREngineControlUnit
-create -track TokioUndergroundRaceTrack
-assign -tunning 3 to -vehicle 2
-assign -tunning 4 to -vehicle 2
-assign -tunning 5 to -vehicle 2
-assign -tunning 6 to -vehicle 2
-assign -tunning 7 to -vehicle 2
-assign -tunning 8 to -vehicle 2
-create -driver LetiSpaghetti
-create -vehicle NissanGTR
-assign -vehicle 11 to -driver 10
-create -tunning ZX8ParallelTwinTurbocharger
-create -tunning ViperGenieIntercooler
-create -tunning HurstCompetitionManualShifter
-create -tunning YokohamaAdvanTiresSet
-create -tunning RemusExhaust
-create -tunning SCTPerformanceEngineControlUnit
-assign -tunning 12 to -vehicle 11
-assign -tunning 13 to -vehicle 11
-assign -tunning 14 to -vehicle 11
-assign -tunning 15 to -vehicle 11
-assign -tunning 16 to -vehicle 11
-assign -tunning 17 to -vehicle 11
-create -vehicle SubaruImprezaWRX
-create -vehicle Nissan350Z
-assign -vehicle 18 to -driver 10
-assign -vehicle 19 to -driver 1
-select -vehicle 11 for -driver 10
-select -vehicle 2 for -driver 1
-assign -driver 1 to -track 9
-assign -driver 10 to -track 9
-run -track 9
-display best 2 times from -track 9
-exit
```

### Sample Output
```
VinBenzin - successfully created!
MitsubishiLancerEvolution - successfully created!
Item with ID:2 assigned successfully!
VortexR35SequentialTurbocharger - successfully created!
EvolutionXPerformanceIntercooler - successfully created!
BMShortShifter - successfully created!
MichelinPilotTiresSet - successfully created!
BorlaExhaust - successfully created!
APREngineControlUnit - successfully created!
TokioUndergroundRaceTrack - successfully created!
Item with ID:3 assigned successfully!
Item with ID:4 assigned successfully!
Item with ID:5 assigned successfully!
Item with ID:6 assigned successfully!
Item with ID:7 assigned successfully!
Item with ID:8 assigned successfully!
LetiSpaghetti - successfully created!
NissanGTR - successfully created!
Item with ID:11 assigned successfully!
ZX8ParallelTwinTurbocharger - successfully created!
ViperGenieIntercooler - successfully created!
HurstCompetitionManualShifter - successfully created!
YokohamaAdvanTiresSet - successfully created!
RemusExhaust - successfully created!
SCTPerformanceEngineControlUnit - successfully created!
Item with ID:12 assigned successfully!
Item with ID:13 assigned successfully!
Item with ID:14 assigned successfully!
Item with ID:15 assigned successfully!
Item with ID:16 assigned successfully!
Item with ID:17 assigned successfully!
SubaruImprezaWRX - successfully created!
Nissan350Z - successfully created!
Item with ID:18 assigned successfully!
Item with ID:19 assigned successfully!
Leti Spaghetti now drives her NissanGTR
Vin Benzin now drives his MitsubishiLancerEvolution
Item with ID:1 assigned successfully!
Item with ID:10 assigned successfully!
Performing drag race on track "Tokio Underground Race Track" with 2 participants.
Best 2 times ever for track "Tokio Underground Race Track":
00:00:33.3380000
00:00:38.8450000
```

### Sample Input
```
-create -driver DominicRendeto
-create -driver LetiSpaghetti
-create -driver Vince
-create -driver VinBenzin
-create -driver Mia
-create -driver Jessi
-create -vehicle NissanGTR
-create -vehicle Nissan350Z
-create -vehicle NissanSkylineR34
-create -vehicle MitsubishiLancerEvolution
-create -vehicle MitsubishiEclipse
-create -vehicle SubaruImprezaWRX
-create -vehicle AcuraIntegraTypeR
-create -tunning VortexR35SequentialTurbocharger
-create -tunning ZX8ParallelTwinTurbocharger
-create -tunning EvolutionXPerformanceIntercooler
-create -tunning ViperGenieIntercooler
-create -tunning BorlaExhaust
-create -tunning MagnaflowExhaust
-create -tunning RemusExhaust
-create -tunning FalkenAzenisTiresSet
-create -tunning MichelinPilotTiresSet
-create -tunning YokohamaAdvanTiresSet
-create -tunning BMShortShifter
-create -tunning HurstCompetitionManualShifter
-create -tunning TWMPerformanceTransmission
-create -tunning APREngineControlUnit
-create -tunning DinanEngineControlUnit
-create -tunning SCTPerformanceEngineControlUnit
-create -track MonacoRaceTrack
-create -track StormblazeRaceTrack
-assign -vehicle 10 to -driver 1
-assign -vehicle 11 to -driver 1
-assign -vehicle 9 to -driver 3
-assign -vehicle 8 to -driver 4
-assign -vehicle 7 to -driver 5
-assign -vehicle 12 to -driver 2
-assign -vehicle 13 to -driver 2
-assign -tunning 14 to -vehicle 10
-assign -tunning 16 to -vehicle 10
-assign -tunning 18 to -vehicle 10
-assign -tunning 22 to -vehicle 10
-assign -tunning 24 to -vehicle 10
-assign -tunning 27 to -vehicle 10
-assign -tunning 15 to -vehicle 7
-assign -tunning 17 to -vehicle 7
-assign -tunning 19 to -vehicle 7
-assign -tunning 23 to -vehicle 7
-assign -tunning 25 to -vehicle 7
-assign -tunning 28 to -vehicle 7
-assign -tunning 20 to -vehicle 13
-assign -tunning 21 to -vehicle 13
-assign -tunning 26 to -vehicle 13
-assign -tunning 29 to -vehicle 13
-select -vehicle 10 for -driver 1
-select -vehicle 12 for -driver 2
-select -vehicle 9 for -driver 3
-select -vehicle 8 for -driver 4
-select -vehicle 7 for -driver 5
-assign -driver 1 to -track 30
-assign -driver 2 to -track 30
-assign -driver 3 to -track 30
-assign -driver 4 to -track 30
-assign -driver 5 to -track 30
-assign -driver 1 to -track 31
-assign -driver 2 to -track 31
-assign -driver 3 to -track 31
-assign -driver 5 to -track 31
-run -track 30
-run -track 31
-display best 3 times from -track 30
-display best 4 times from -track 31
-create -tunning HellcatMotor
-create -tunning CentaurPulseMotor
-create -tunning IronHorseMotor
-create -tunning ShockblazePulsejetMotor
-create -tunning TyphoonPulseMotor
-create -tunning StingrayMotor
-assign -tunning 35 to -vehicle 10
-assign -tunning 32 to -vehicle 11
-assign -tunning 33 to -vehicle 7
-assign -tunning 34 to -vehicle 8
-assign -tunning 36 to -vehicle 9
-assign -tunning 37 to -vehicle 13
-assign -driver 1 to -track 30
-assign -driver 2 to -track 30
-assign -driver 3 to -track 30
-assign -driver 4 to -track 30
-assign -driver 5 to -track 30
-run -track 30
-display best 3 times from -track 30
-exit
```

### Sample Output
```
DominicRendeto - successfully created!
LetiSpaghetti - successfully created!
Vince - successfully created!
VinBenzin - successfully created!
Mia - successfully created!
Jessi - successfully created!
NissanGTR - successfully created!
Nissan350Z - successfully created!
NissanSkylineR34 - successfully created!
MitsubishiLancerEvolution - successfully created!
MitsubishiEclipse - successfully created!
SubaruImprezaWRX - successfully created!
AcuraIntegraTypeR - successfully created!
VortexR35SequentialTurbocharger - successfully created!
ZX8ParallelTwinTurbocharger - successfully created!
EvolutionXPerformanceIntercooler - successfully created!
ViperGenieIntercooler - successfully created!
BorlaExhaust - successfully created!
MagnaflowExhaust - successfully created!
RemusExhaust - successfully created!
FalkenAzenisTiresSet - successfully created!
MichelinPilotTiresSet - successfully created!
YokohamaAdvanTiresSet - successfully created!
BMShortShifter - successfully created!
HurstCompetitionManualShifter - successfully created!
TWMPerformanceTransmission - successfully created!
APREngineControlUnit - successfully created!
DinanEngineControlUnit - successfully created!
SCTPerformanceEngineControlUnit - successfully created!
MonacoRaceTrack - successfully created!
StormblazeRaceTrack - successfully created!
Item with ID:10 assigned successfully!
Item with ID:11 assigned successfully!
Item with ID:9 assigned successfully!
Item with ID:8 assigned successfully!
Item with ID:7 assigned successfully!
Item with ID:12 assigned successfully!
Item with ID:13 assigned successfully!
Item with ID:14 assigned successfully!
Item with ID:16 assigned successfully!
Item with ID:18 assigned successfully!
Item with ID:22 assigned successfully!
Item with ID:24 assigned successfully!
Item with ID:27 assigned successfully!
Item with ID:15 assigned successfully!
Item with ID:17 assigned successfully!
Item with ID:19 assigned successfully!
Item with ID:23 assigned successfully!
Item with ID:25 assigned successfully!
Item with ID:28 assigned successfully!
Item with ID:20 assigned successfully!
Item with ID:21 assigned successfully!
Item with ID:26 assigned successfully!
Item with ID:29 assigned successfully!
Dominic Rendeto now drives his MitsubishiLancerEvolution
Leti Spaghetti now drives her SubaruImprezaWRX
Vince now drives his NissanSkylineR34
Vin Benzin now drives his Nissan350Z
Mia now drives her NissanGTR
Item with ID:1 assigned successfully!
Item with ID:2 assigned successfully!
Item with ID:3 assigned successfully!
Item with ID:4 assigned successfully!
Item with ID:5 assigned successfully!
Item with ID:1 assigned successfully!
Item with ID:2 assigned successfully!
Item with ID:3 assigned successfully!
Item with ID:5 assigned successfully!
Performing drag race on track "Monaco Race Track" with 5 participants.
Performing drag race on track "Stormblaze Race Track" with 4 participants.
Best 3 times ever for track "Monaco Race Track":
00:00:13.4700000
00:00:15.0980000
00:00:26
Best 4 times ever for track "Stormblaze Race Track":
00:00:06.8480000
00:00:07.5790000
00:00:13.1790000
00:00:13.7810000
HellcatMotor - successfully created!
CentaurPulseMotor - successfully created!
IronHorseMotor - successfully created!
ShockblazePulsejetMotor - successfully created!
TyphoonPulseMotor - successfully created!
StingrayMotor - successfully created!
Item with ID:35 assigned successfully!
Item with ID:32 assigned successfully!
Item with ID:33 assigned successfully!
Item with ID:34 assigned successfully!
Item with ID:36 assigned successfully!
Item with ID:37 assigned successfully!
Item with ID:1 assigned successfully!
Item with ID:2 assigned successfully!
Item with ID:3 assigned successfully!
Item with ID:4 assigned successfully!
Item with ID:5 assigned successfully!
Performing drag race on track "Monaco Race Track" with 5 participants.
Best 3 times ever for track "Monaco Race Track":
00:00:09.5050000
00:00:10.9730000
00:00:12.4810000
```

### Sample Input
```
-create -driver DominicRendeto
-create -driver LetiSpaghetti
-create -driver Vince
-create -driver VinBenzin
-create -driver Mia
-create -driver Jessi
-create -vehicle NissanGTR
-create -vehicle Nissan350Z
-create -vehicle NissanSkylineR34
-create -vehicle MitsubishiLancerEvolution
-create -vehicle MitsubishiEclipse
-create -vehicle SubaruImprezaWRX
-create -vehicle AcuraIntegraTypeR
-create -tunning VortexR35SequentialTurbocharger
-create -tunning ZX8ParallelTwinTurbocharger
-create -tunning EvolutionXPerformanceIntercooler
-create -tunning ViperGenieIntercooler
-create -tunning BorlaExhaust
-create -tunning MagnaflowExhaust
-create -tunning RemusExhaust
-create -tunning FalkenAzenisTiresSet
-create -tunning MichelinPilotTiresSet
-create -tunning YokohamaAdvanTiresSet
-create -tunning BMShortShifter
-create -tunning HurstCompetitionManualShifter
-create -tunning TWMPerformanceTransmission
-create -tunning APREngineControlUnit
-create -tunning DinanEngineControlUnit
-create -tunning SCTPerformanceEngineControlUnit
-create -track MonacoRaceTrack
-create -track StormblazeRaceTrack
-assign -vehicle 10 to -driver 1
-assign -vehicle 11 to -driver 1
-assign -vehicle 9 to -driver 3
-assign -vehicle 8 to -driver 4
-assign -vehicle 7 to -driver 5
-assign -vehicle 12 to -driver 2
-assign -vehicle 13 to -driver 2
-assign -tunning 14 to -vehicle 10
-assign -tunning 16 to -vehicle 10
-assign -tunning 18 to -vehicle 10
-assign -tunning 22 to -vehicle 10
-assign -tunning 24 to -vehicle 10
-assign -tunning 27 to -vehicle 10
-assign -tunning 15 to -vehicle 7
-assign -tunning 17 to -vehicle 7
-assign -tunning 19 to -vehicle 7
-assign -tunning 23 to -vehicle 7
-assign -tunning 25 to -vehicle 7
-assign -tunning 28 to -vehicle 7
-assign -tunning 20 to -vehicle 13
-assign -tunning 21 to -vehicle 13
-assign -tunning 26 to -vehicle 13
-assign -tunning 29 to -vehicle 13
-select -vehicle 10 for -driver 1
-select -vehicle 12 for -driver 2
-select -vehicle 9 for -driver 3
-select -vehicle 8 for -driver 4
-select -vehicle 7 for -driver 5
-assign -driver 1 to -track 30
-assign -driver 1 to -track 30
-assign -driver 2 to -track 30
-assign -driver 3 to -track 30
-assign -driver 4 to -track 30
-assign -driver 5 to -track 30
-assign -driver 1 to -track 31
-assign -driver 2 to -track 31
-assign -driver 3 to -track 31
-assign -driver 5 to -track 31
-run -track 30
-run -track 31
-display best 3 times from -track 30
-display best 4 times from -track 31
-create -tunning HellcatMotor
-create -tunning CentaurPulseMotor
-create -tunning IronHorseMotor
-create -tunning ShockblazePulsejetMotor
-create -tunning TyphoonPulseMotor
-create -tunning StingrayMotor
-assign -tunning 35 to -vehicle 10
-assign -tunning 32 to -vehicle 11
-assign -tunning 32 to -vehicle 11
-assign -tunning 33 to -vehicle 7
-assign -tunning 34 to -vehicle 8
-assign -tunning 36 to -vehicle 9
-assign -tunning 36 to -vehicle 9
-assign -tunning 37 to -vehicle 13
-assign -driver 1 to -track 30
-assign -driver 2 to -track 30
-assign -driver 3 to -track 30
-assign -driver 4 to -track 30
-assign -driver 5 to -track 30
-run -track 30
-display best 3 times from -track 30
-exit
```

### Sample Output
```
DominicRendeto - successfully created!
LetiSpaghetti - successfully created!
Vince - successfully created!
VinBenzin - successfully created!
Mia - successfully created!
Jessi - successfully created!
NissanGTR - successfully created!
Nissan350Z - successfully created!
NissanSkylineR34 - successfully created!
MitsubishiLancerEvolution - successfully created!
MitsubishiEclipse - successfully created!
SubaruImprezaWRX - successfully created!
AcuraIntegraTypeR - successfully created!
VortexR35SequentialTurbocharger - successfully created!
ZX8ParallelTwinTurbocharger - successfully created!
EvolutionXPerformanceIntercooler - successfully created!
ViperGenieIntercooler - successfully created!
BorlaExhaust - successfully created!
MagnaflowExhaust - successfully created!
RemusExhaust - successfully created!
FalkenAzenisTiresSet - successfully created!
MichelinPilotTiresSet - successfully created!
YokohamaAdvanTiresSet - successfully created!
BMShortShifter - successfully created!
HurstCompetitionManualShifter - successfully created!
TWMPerformanceTransmission - successfully created!
APREngineControlUnit - successfully created!
DinanEngineControlUnit - successfully created!
SCTPerformanceEngineControlUnit - successfully created!
MonacoRaceTrack - successfully created!
StormblazeRaceTrack - successfully created!
Item with ID:10 assigned successfully!
Item with ID:11 assigned successfully!
Item with ID:9 assigned successfully!
Item with ID:8 assigned successfully!
Item with ID:7 assigned successfully!
Item with ID:12 assigned successfully!
Item with ID:13 assigned successfully!
Item with ID:14 assigned successfully!
Item with ID:16 assigned successfully!
Item with ID:18 assigned successfully!
Item with ID:22 assigned successfully!
Item with ID:24 assigned successfully!
Item with ID:27 assigned successfully!
Item with ID:15 assigned successfully!
Item with ID:17 assigned successfully!
Item with ID:19 assigned successfully!
Item with ID:23 assigned successfully!
Item with ID:25 assigned successfully!
Item with ID:28 assigned successfully!
Item with ID:20 assigned successfully!
Item with ID:21 assigned successfully!
Item with ID:26 assigned successfully!
Item with ID:29 assigned successfully!
Dominic Rendeto now drives his MitsubishiLancerEvolution
Leti Spaghetti now drives her SubaruImprezaWRX
Vince now drives his NissanSkylineR34
Vin Benzin now drives his Nissan350Z
Mia now drives her NissanGTR
Item with ID:1 assigned successfully!
Cannot sign the same participant to a track
Item with ID:2 assigned successfully!
Item with ID:3 assigned successfully!
Item with ID:4 assigned successfully!
Item with ID:5 assigned successfully!
Item with ID:1 assigned successfully!
Item with ID:2 assigned successfully!
Item with ID:3 assigned successfully!
Item with ID:5 assigned successfully!
Performing drag race on track "Monaco Race Track" with 5 participants.
Performing drag race on track "Stormblaze Race Track" with 4 participants.
Best 3 times ever for track "Monaco Race Track":
00:00:13.4700000
00:00:15.0980000
00:00:26
Best 4 times ever for track "Stormblaze Race Track":
00:00:06.8480000
00:00:07.5790000
00:00:13.1790000
00:00:13.7810000
HellcatMotor - successfully created!
CentaurPulseMotor - successfully created!
IronHorseMotor - successfully created!
ShockblazePulsejetMotor - successfully created!
TyphoonPulseMotor - successfully created!
StingrayMotor - successfully created!
Item with ID:35 assigned successfully!
Item with ID:32 assigned successfully!
Cannot add multiple parts of the same type to a vehicle
Parameter name: HellcatMotor
Item with ID:33 assigned successfully!
Item with ID:34 assigned successfully!
Item with ID:36 assigned successfully!
Cannot add multiple parts of the same type to a vehicle
Parameter name: TyphoonPulseMotor
Item with ID:37 assigned successfully!
Item with ID:1 assigned successfully!
Item with ID:2 assigned successfully!
Item with ID:3 assigned successfully!
Item with ID:4 assigned successfully!
Item with ID:5 assigned successfully!
Performing drag race on track "Monaco Race Track" with 5 participants.
Best 3 times ever for track "Monaco Race Track":
00:00:09.5050000
00:00:10.9730000
00:00:12.4810000
```
