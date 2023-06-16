import React from 'react';
import { PatientListItem } from './APIServices/PatientDataContract';
import PatientListComp from './components/PatientListComp/PatientListComp';
import { PatientServiceApi as PatientApi } from './APIServices/PatientApi';
import config from './ConnectionStrings';
import ApiContext from './ApiContext';
import { InvoiceApi } from './APIServices/InvoiceApi';
import { InventoryAPI } from './APIServices/InventoryApi';
import { StaffApi } from './APIServices/StaffApi';
import { RoomApi } from './APIServices/RoomApi';
import { MedicalRecordsApi } from './APIServices/MedicalRecordsApi';
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom';
import PatientsPage from './pages/PatientsPage';
import PatientDetail from './components/PatientDetail/PatientDetail';
import StaffPage from './pages/StaffPage';
import StaffDetail from './components/StaffDetail/StaffDetail';
import Navbar from './components/NavBar/Navbar';
import RoomsPage from './pages/RoomsPage';


function App() {


  const patientApi = new PatientApi({ baseUrl: config.PatientServiceUrl })
  let patientsData: PatientListItem[] =
    [
      { id: '1', firstName: '1', middleName: '1', lastName: '1' },
      { id: '2', firstName: '2', middleName: '2', lastName: '2' },
      { id: '3', firstName: '3', middleName: '3', lastName: '3' },
      { id: '4', firstName: '4', middleName: '4', lastName: '4' },
      { id: '5', firstName: '5', middleName: '5', lastName: '5' },
      { id: '6', firstName: '6', middleName: '6', lastName: '6' },
    ];
  const _apiContext = {
    Patient: new PatientApi({ baseUrl: config.PatientServiceUrl }),
    Invoice: new InvoiceApi({ baseUrl: config.InvoiceServiceUrl }),
    Inventory: new InventoryAPI({ baseUrl: config.InventoryServiceUrl }),
    Staff: new StaffApi({ baseUrl: config.StaffServiceUrl }),
    Room: new RoomApi({ baseUrl: config.RoomServiceUrl }),
    MedicalRecord: new MedicalRecordsApi({ baseUrl: config.MedicalRecordServiceUrl })
  };
  return (
    <div className="App">
      <ApiContext.Provider value={_apiContext}>
        <BrowserRouter>
        <Navbar />
          <Routes>
            <Route path="/patients" element={<PatientsPage />} />
            <Route path="/patients/detail/:patientId" element={<PatientDetail />} />
            <Route path="/staff" element={<StaffPage />} />
            <Route path="/staff/detail/:staffId" element={<StaffDetail />} />
            <Route path="/room" element={<RoomsPage />} />

          </Routes>
        </BrowserRouter>
      </ApiContext.Provider>
    </div>
  );
}

export default App;
