import React, { useContext, useEffect, useState } from 'react'
import { PatientListItem } from '../../APIServices/PatientDataContract'
import './PatientListItemComp.css'
import { PatientUpdateDTO } from '../../APIServices/PatientDataContract'
import { PatientServiceApi } from '../../APIServices/PatientApi'
import ModalForm from '../ModalForm/ModalForm'
import ApiContext from '../../ApiContext'
import { Link } from 'react-router-dom'

type Props = {
    patient: PatientListItem,
    updPat(x :PatientUpdateDTO) : void;
}

const PatientListItemComp: React.FC<Props> = (props) => {
    const apiContext = useContext(ApiContext)
    useEffect(() => {
        const fetchData = async () => {
            try {
                let patient = await apiContext?.Patient.patientGet(props.patient.id!);
                setUpdateData(patient?.data);
                setTempUpdateData(patient?.data);
                setTempUpdateData(patient?.data)
                setUpdateData(patient?.data)
                console.log(patient?.data)
            }
            catch (error) {
                console.log("Не удалось загрузить данные о пациенте")
            }
        }
        fetchData();
    }, []);
    const [updateData, setUpdateData] = useState<PatientUpdateDTO>();
    const [tempUpdateData, setTempUpdateData] = useState<PatientUpdateDTO>();
    const [updateModalState, setUpdateModalState] = useState(false);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setTempUpdateData({
            ...tempUpdateData,
            [e.target.name]: e.target.value
        });
    };
    const handlePhoneChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        var phone = e.target.value;
        var clearPhone = phone.replace(/\D/g, '');
        setTempUpdateData({
            ...tempUpdateData,
            phoneNumber: clearPhone
        })
    };
    const saveUpdate = async ()=>{
        setUpdateData(tempUpdateData);
        tempUpdateData && apiContext?.Patient.patientUpdate(tempUpdateData);
        props.updPat(tempUpdateData!);
    }

    
    return (
        <div className="itemRow">
            <span>{props.patient.lastName} {props.patient.firstName} {props.patient.middleName}</span>
            <div className='buttonsContainer'>
                <Link to={'detail/' + props.patient.id}>
                <button className="btn waves-effect waves-light blue darken-1 btn-small" type="button">Открыть
                    <i className="material-icons right">person</i>
                </button>
                </Link>
                <button className="btn waves-effect waves-light blue darken-1 btn-small" type="button" onClick={() => { setUpdateModalState(true); console.log(updateModalState) }}>Редактировать
                    <i className="material-icons right">mode_edit</i>
                </button>
            </div>
            <ModalForm active={updateModalState} setActive={setUpdateModalState}>
                <form>
                    <input type="text" name="lastName" value={tempUpdateData?.lastName} onChange={handleChange}></input>
                    <input type="text" name="firstName" value={tempUpdateData?.firstName} onChange={handleChange}></input>
                    <input type="text" name="middleName" value={tempUpdateData?.middleName} onChange={handleChange}></input>
                    <input type="text" name="phonenumber" value={tempUpdateData?.phoneNumber} onChange={handlePhoneChange}></input>
                    <input type="date" name="birthDate" value={tempUpdateData?.birthDate} onChange={handleChange}></input>
                    <button className="btn waves-effect waves-light blue darken-1 btn-small" onClick={(e) => { e.preventDefault(); console.log(updateData); setUpdateModalState(false); saveUpdate(); }}>Сохранить</button>
                    <button className="btn waves-effect waves-light blue darken-1 btn-small" onClick={(e) => { e.preventDefault(); console.log("Закрытие"); setUpdateModalState(false); setTempUpdateData(updateData) }}>Закрыть</button>
                </form>
            </ModalForm>

        </div>
    );
};

export default PatientListItemComp;