import React, { useContext, useEffect, useState } from 'react'
import { PatientDTO } from '../../APIServices/PatientDataContract'
import ApiContext from '../../ApiContext'
import { RoomMoveDTO, RoomMoveType } from '../../APIServices/RoomServiceDataContract'
import { useParams } from 'react-router-dom'
import classes from './PatientDetail.module.css'


const PatientDetail: React.FC = () => {
    const { patientId } = useParams()
    const apiContext = useContext(ApiContext);
    const [patient, setPatient] = useState<PatientDTO>();
    const [room, setRoom] = useState("Не найден")
    const [loaded, setLoaded] = useState(false)
    const refresData = async()=>{
        const fetchData = async () => {
            try {
                var response = await apiContext?.Patient.patientGet(patientId!);
                if (response?.ok) {
                    setPatient(response?.data)
                    setLoaded(true)
                }
                else { setLoaded(false) }
            }
            catch (error) {
                setLoaded(false);
                // console.log(error)
            }
            try{
                let roomResponse = await apiContext?.Room.roomMovesGetRoomMovesByPatient(patient?.id!)

                if (roomResponse?.ok) {
                    roomResponse.data.roomMoves?.sort(compareDates);
                    let lastRoomMove = roomResponse.data.roomMoves![roomResponse.data.roomMoves!.length - 1]
                    if (lastRoomMove.moveType === RoomMoveType.Settlement) {
                        setRoom(lastRoomMove.roomNumber!.toString());
                    }
                }
            }
            catch(error){
                // console.log(error)
            }
        }
        fetchData();
}
    useEffect(() => {
        refresData()},[]);
    const compareDates = (a: RoomMoveDTO, b: RoomMoveDTO) => {
        const DateA = new Date(a.date!);
        const DateB = new Date(b.date!);
        if (DateA < DateB) {
            return -1;
        } else if (DateA > DateB) {
            return 1
        }
        else { return 0; }
    }

    return (
        <div className={classes.container}>
            <div>
                <table>
                 <tr>
                    <td>ФИО:</td>
                    <td>{patient?.lastName} {patient?.firstName} {patient?.middleName}</td>
                 </tr>
                 <tr>
                    <td>Номер телефона:</td>
                    <td>{patient?.phoneNumber}</td>
                 </tr>
                 <tr>
                    <td>Дата рождения:</td>
                    <td>{patient?.birthDate}</td>
                 </tr>
                 <tr>
                    <td>Дата регистрации:</td>
                    <td>{patient?.dateRegistered}</td>
                 </tr>
                 <tr>
                    <td>Дата выписки:</td>
                    <td>{!patient?.discharged && patient?.dateDischarged === null || patient?.dateDischarged === undefined ? "" : patient?.dateDischarged}</td>
                 </tr>
                 <tr>
                    <td>Текущий статус:</td>
                    <td>{patient?.discharged === true ? "Выписан" : "Зарегистрирован"}</td>
                 </tr>
                 <tr>
                    <td>Номер комнаты:</td>
                    <td>{room}</td>
                 </tr>   
                </table>
            </div>
            <button
                className="btn waves-effect waves-light blue darken-1 btn-small"
                type="button">
                Медкарта
                <i className="material-icons right">local_hospital</i>
            </button>
            <button
                className="btn waves-effect waves-light blue darken-1 btn-small"
                type="button" disabled = {!patient?.discharged} onClick={async ()=>{
                    try{
                        await apiContext?.Patient.patientRegister(patientId!);
                        setPatient({...patient, discharged:false});
                        refresData();
                        console.log(patient);
                    }
                    catch(error){
                        console.log(error);
                    }
                }
                    
                }>
                Зарегистрировать
                <i className="material-icons right">arrow_upward</i>
            </button>
            <button
                className="btn waves-effect waves-light blue darken-1 btn-small"
                type="button" disabled = {patient?.discharged} onClick={async ()=>{
                    try{
                        await apiContext?.Patient.patientDischarge(patientId!);
                        setPatient({...patient, discharged:true});
                        console.log(patient);
                        await refresData();
                    }
                    catch(error){
                        console.log(error);
                    }
                }}>
                Выписать
                <i className="material-icons right">arrow_downward</i>
            </button>
            <button
                className="btn waves-effect waves-light blue darken-1 btn-small"
                type="button">
                Счет не оплату
                <i className="material-icons right">attach_money</i>
            </button>
            <button
                className="btn waves-effect waves-light blue darken-1 btn-small"
                type="button">
                Переселить в другой номер
                <i className="material-icons right">shuffle</i>
            </button>
        </div>
    )
}
export default PatientDetail;