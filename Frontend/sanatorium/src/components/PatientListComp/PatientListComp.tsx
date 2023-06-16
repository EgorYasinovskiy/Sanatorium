import React, { useContext, useState } from 'react'
import { PatientList, PatientListItem, PatientUpdateDTO } from '../../APIServices/PatientDataContract';
import { PatientServiceApi } from '../../APIServices/PatientApi';
import PatientListItemComp from '../PatientListItemComp/PatientListItemComp';
import classes from './PatientListComp.module.css'
import ApiContext from '../../ApiContext';
type Props = {
    PatientList: PatientList,
}

const PatientListComp: React.FC<Props> = (props) => {
    var apiContext = useContext(ApiContext);
    const [patients, setPatients] = useState(props.PatientList.patients);
    const updPatient = (patient : PatientUpdateDTO) => {
        const patIndex = patients?.findIndex(x=>x.id == patient.id);
        if(patIndex != -1){
            patients![patIndex!]!.firstName = patient.firstName;
            patients![patIndex!]!.lastName = patient.lastName;
            patients![patIndex!]!.middleName = patient.middleName;
            setPatients(patients);
        }
    }
    return (
        <div className={classes.listContainer}>
            <div className={classes.header}>
                <h3 className=''> Список пацинентов</h3>
                <button className="btn waves-effect waves-light blue darken-1 btn-small">Зарегистрировать нового</button>
            </div>
            {patients && patients.map((item) => (
                <PatientListItemComp patient={item}
                    key={item.id} updPat={updPatient}/>
            ))}
            {!patients || patients.length === 0 &&
                <div>
                    <h3>Не удалось получить список пациентов</h3>
                </div >
            }
        </div>
    )
}
export default PatientListComp;