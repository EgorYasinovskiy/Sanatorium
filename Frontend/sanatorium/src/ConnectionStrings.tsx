interface Config {
    PatientServiceUrl: string;
    InvoiceServiceUrl: string;
    InventoryServiceUrl: string;
    RoomServiceUrl: string;
    StaffServiceUrl: string;
    MedicalRecordServiceUrl: string;
}

const config: Config = {
    PatientServiceUrl: "http://localhost:4444",
    InvoiceServiceUrl: "https://localhost:2",
    InventoryServiceUrl: "https://localhost:3",
    RoomServiceUrl: "http://localhost:5555",
    MedicalRecordServiceUrl: "https://localhost:5",
    StaffServiceUrl: "http://localhost:5214",
}

export default config;