export class PatientList{
    items : PatientListItem[];

    constructor(jsonData: any){
        this.items = jsonData.Patients.map((item:any)=>({
            Id: item.Id,
            FirstName: item.FirstName,
            MiddleName : item.MiddleName,
            LastName : item.LastName
        }));
    }
}