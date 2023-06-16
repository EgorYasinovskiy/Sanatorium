import React, { useContext, useEffect, useState } from 'react'
import ModalForm from '../ModalForm/ModalForm'
import ApiContext from '../../ApiContext'
import { Link } from 'react-router-dom'
import { StaffList, StaffListItem, UpdateStaffDTO } from '../../APIServices/StaffServiceDataContract'
import classes from './StaffListItemComp.module.css'

type Props = {
    staff: StaffListItem,
    updPat(x :UpdateStaffDTO) : void;
}

const StaffListItemComp: React.FC<Props> = (props) => {
    const apiContext = useContext(ApiContext)
    const [updateData, setUpdateData] = useState<UpdateStaffDTO>();
    const [tempUpdateData, setTempUpdateData] = useState<UpdateStaffDTO>();
    const [updateModalState, setUpdateModalState] = useState(false);
    useEffect(() => {
        const fetchData = async () => {
            try {
                let staff = await apiContext?.Staff.staffGetStaff(props.staff.id!);
                setUpdateData(staff?.data);
                setTempUpdateData(staff?.data);
                setTempUpdateData(staff?.data)
                setUpdateData(staff?.data)
                console.log(staff?.data)
            }
            catch (error) {
                console.log("Не удалось загрузить данные о пациенте")
            }
        }
        fetchData();
    }, []);

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
    const saveUpdate = () =>{
        setUpdateData(tempUpdateData);
        tempUpdateData && apiContext?.Staff.staffUpdate(tempUpdateData);
        props.updPat(tempUpdateData!);
    }

    
    return (
        <div className={classes.itemRow}>
            <span>{props.staff.lastName} {props.staff.firstName} {props.staff.middleName} | {props.staff.position}</span>
            <div className={classes.buttonsContainer}>
                <Link to={'detail/' + props.staff.id}>
                <button className="btn waves-effect waves-light blue darken-1 btn-small" type="button">Открыть
                    <i className="material-icons right">person</i>
                </button>
                </Link>
                <button className="btn waves-effect waves-light blue darken-1 btn-small" type="button" onClick={() => { setUpdateModalState(true); console.log(updateModalState) }}>Редактировать
                    <i className="material-icons right">mode_edit</i>
                </button>
                <button className="btn waves-effect waves-light red darken-1 btn-small" type="button" onClick={() => { setUpdateModalState(true); console.log(updateModalState) }}>Удалить
                    <i className="material-icons right">delete</i>
                </button>
            </div>
            <ModalForm active={updateModalState} setActive={setUpdateModalState}>
                <form>
                    <input type="text" name="lastName" value={tempUpdateData?.lastName} onChange={handleChange}></input>
                    <input type="text" name="firstName" value={tempUpdateData?.firstName} onChange={handleChange}></input>
                    <input type="text" name="middleName" value={tempUpdateData?.middleName} onChange={handleChange}></input>
                    <input type="text" name="phonenumber" value={tempUpdateData?.phoneNumber} onChange={handlePhoneChange}></input>
                    <input type="date" name="birthDate" value={tempUpdateData?.birthdate} onChange={handleChange}></input>
                    <button className="btn waves-effect waves-light blue darken-1 btn-small" onClick={(e) => { e.preventDefault(); console.log(updateData); setUpdateModalState(false); saveUpdate(); }}>Сохранить</button>
                    <button className="btn waves-effect waves-light blue darken-1 btn-small" onClick={(e) => { e.preventDefault(); console.log("Закрытие"); setUpdateModalState(false); setTempUpdateData(updateData) }}>Закрыть</button>
                </form>
            </ModalForm>

        </div>
    );
};

export default StaffListItemComp;