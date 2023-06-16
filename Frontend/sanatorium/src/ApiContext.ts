import { InventoryAPI } from "./APIServices/InventoryApi";
import { InvoiceApi } from "./APIServices/InvoiceApi";
import { MedicalRecordsApi } from "./APIServices/MedicalRecordsApi";
import { PatientServiceApi as PatientApi } from "./APIServices/PatientApi";
import { RoomApi } from "./APIServices/RoomApi";
import { StaffApi } from "./APIServices/StaffApi";
import config from "./ConnectionStrings";
import React from "react";

interface ApiContextInterface{
    Inventory : InventoryAPI,
    Invoice : InvoiceApi,
    MedicalRecord : MedicalRecordsApi,
    Patient : PatientApi,
    Room : RoomApi,
    Staff : StaffApi
}
export const ApiContext = React.createContext<ApiContextInterface|undefined>(undefined);
export default ApiContext;