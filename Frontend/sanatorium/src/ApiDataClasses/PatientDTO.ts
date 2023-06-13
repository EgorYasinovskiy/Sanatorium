export class PatientDTO{
    Id : string;
    FirstName: string;
    LastName : string;
    MiddleName : string;
    BirthDate : Date;
    PhoneNumber : string;

    DateRegistered : Date;
    DateDischarged : null | Date;
    Discharged : boolean;
    
    
    constructor(jsonData: any){
        this.Id = jsonData.Id;
        this.FirstName = jsonData.FirstName;
        this.LastName = jsonData.LastName,
        this.MiddleName = jsonData.MiddleName;
        this.BirthDate = new Date(jsonData.BirthDate);
        this.PhoneNumber = jsonData.PhoneNumber;
        this.DateRegistered = new Date(jsonData.DateRegistered);
        if(jsonData.DateDischarged && jsonData.DateDischarged !== ''){
            this.DateDischarged = new Date(jsonData.DateRegistered);
        }
        else{
            this.DateDischarged = null;
        }
        this.Discharged = jsonData.Discharged;
    }
}