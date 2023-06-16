import React, { useContext, useEffect, useState } from 'react'
import ApiContext from '../../ApiContext'
import { RoomMoveDTO, RoomMoveType } from '../../APIServices/RoomServiceDataContract'
import { useParams } from 'react-router-dom'
import classes from './StaffDetail.module.css'
import { StaffDTO, UpdateStaffDTO } from '../../APIServices/StaffServiceDataContract'
import ModalForm from '../ModalForm/ModalForm'


const StaffDetail: React.FC = () => {
    const { staffId } = useParams()
    const apiContext = useContext(ApiContext);
    const [staff, setStaff] = useState<StaffDTO>();
    const [position, setPos] = useState<string>();
    const [loaded, setLoaded] = useState(false)
    const [modalActive, setModalActive] = useState(false);
    const refresData = async () => {
        const fetchData = async () => {
            try {
                var response = await apiContext?.Staff.staffGetStaff(staffId!);
                if (response?.ok) {
                    setStaff(response?.data)
                    setLoaded(true)
                }
                else { setLoaded(false) }
            }
            catch (error) {
                setLoaded(false);
                // console.log(error)
            }
        }

        fetchData();
    }

    useEffect(() => {
        refresData()
    }, []);
    return (
        <div className={classes.container}>
            <div>
                <table>
                    <tr>
                        <td colSpan={2}><h4>{staff?.lastName} {staff?.firstName} {staff?.middleName}</h4></td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td>Номер телефона:</td>
                        <td>{staff?.phoneNumber}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td>Дата рождения:</td>
                        <td>{staff?.birthDate}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td>Кабинет №:</td>
                        <td>{staff?.cabinetNumber}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td>Руководитель: </td>
                        <td>{staff?.managerName}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td>Должность</td>
                        <td>{staff?.position}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button"
                                onClick={() => {setModalActive(true);setPos(staff?.position!)}}>
                                <i className="material-icons">edit</i>
                            </button>
                            <ModalForm active={modalActive} setActive={setModalActive}>
                                <form>
                                    <span>Новая должность:</span> <input type="text" value={position} onChange={(e:React.ChangeEvent<HTMLInputElement>)=>setPos(e.target.value)}/>
                                    <div className='center'>
                                    <button
                                        className={"btn waves-effect waves-light blue darken-1 btn-small "}
                                        type="button"
                                        onClick={()=>{
                                          apiContext?.Staff.changePosition({staffId :staff?.id ,newPosition:position})
                                          setStaff({...staff, position: position})
                                        }}>
                                            Сохранить
                                    </button>
                                    <button
                                        className={"btn waves-effect waves-light blue darken-1 btn-small "}
                                        type="button" onClick={()=>{setModalActive(false);}}>
                                            Закрыть
                                    </button>
                                    </div>
                                </form>
                            </ModalForm>
                        </td>
                    </tr>
                    <tr>
                        <td>График работы:</td>
                        <td>{staff?.dayWork}\{staff?.dayHoliday}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td>Работает с:</td>
                        <td>{staff?.workStart}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td>Ставка в час:</td>
                        <td>{staff?.salaryPerHour}</td>
                        <td>
                            <button
                                className={"btn waves-effect waves-light blue darken-1 btn-small " + classes.editBtn}
                                type="button">
                                <i className="material-icons">edit</i>
                            </button>
                        </td>
                    </tr>
                </table>
            </div>

            <button
                className={"btn waves-effect waves-light red darken-1 btn-small " + classes.delete}
                type="button">
                <i className="material-icons ">delete</i>
                <span className={classes.delText}>Удалить</span>
                <br />
            </button>

        </div>
    )
}
export default StaffDetail;