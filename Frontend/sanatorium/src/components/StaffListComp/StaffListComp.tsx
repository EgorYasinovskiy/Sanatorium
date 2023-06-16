import React, { useContext, useState } from 'react'

import classes from './StaffListComp.module.css'
import ApiContext from '../../ApiContext';
import { CreateStaffDTO, StaffList, StaffListItem, UpdateStaffDTO } from '../../APIServices/StaffServiceDataContract';
import ModalForm from '../ModalForm/ModalForm';
import StaffListItemComp from '../StaffListItem/StaffListItemComp';
import { create } from 'domain';
type Props = {
    StaffList: StaffList,
    setStaffList(staffList: StaffList): void;
}
const StaffListComp: React.FC<Props> = (props) => {
    var apiContext = useContext(ApiContext);
    const [createDto, setCreateDto] = useState<CreateStaffDTO>()
    const [staff, setStaff] = useState(props.StaffList.staff);
    const [modalactive, setModalActive] = useState(false)
    const clearObject = () => {
        const today = new Date()
        const todayString = today.getFullYear().toString() + "-" + (today.getMonth() < 9 ? "0" + (today.getMonth() + 1).toString() : today.getMonth() + 1).toString() + "-" + today.getDate();
        setCreateDto({
            dayHoliday: 7,
            dayWork: 0,
            workStart: todayString,
            firstName: "",
            lastName: "",
            middleName: "",
            managerId: null,
            position: "",
            salaryPerHour: 0,
            phoneNumber: "",
            birthDate: todayString
        })
    }
    const updStaff = (updStaff: UpdateStaffDTO) => {
        const index = staff?.findIndex(x => x.id == updStaff.id);
        if (index != -1) {
            staff![index!]!.firstName = updStaff.firstName;
            staff![index!]!.lastName = updStaff.lastName;
            staff![index!]!.middleName = updStaff.middleName;
            staff![index!].phoneNumber = updStaff.phoneNumber;
            staff![index!].birthDate = updStaff.birthdate
            setStaff(staff);
        }
    }
    const handleChage = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.name === "phoneNumber") {
            let value: string;
            value = e.target.value.replace(/\D/g, '');
            setCreateDto({ ...createDto, [e.target.name]: value })
        }
        else if (e.target.name === "dayWork") {
            let value: number;
            value = Number(e.target.value);
            if (value > 7) {
                value = 7;
            }
            if (value < 0) {
                value = 0;
            }
            console.log(value);
            setCreateDto({ ...createDto, dayWork: value, dayHoliday: 7 - value })
        }
        else {
            setCreateDto({
                ...createDto, [e.target.name]: e.target.type === "number" ? Number(e.target.value) : e.target.value
            });
        }
    }
    const closeModal = () => {
        setModalActive(false);
        clearObject();
    }
    const CreateStaff = async () => {
        try {
            var newStaff = createDto && await apiContext?.Staff.staffCreate(createDto);
            if (newStaff?.ok) {
                var newStaffData = newStaff.data;
                var newStaffListItemDto: StaffListItem = {
                    firstName: newStaffData.firstName,
                    lastName: newStaffData.lastName,
                    middleName: newStaffData.middleName,
                    phoneNumber: newStaffData.phoneNumber,
                    birthDate: newStaffData.birthDate
                }
                var newList = [...staff!, newStaffListItemDto]
                props.setStaffList({ staff: newList });
                setStaff(newList);
            }
        }
        catch (error) {
            console.log(error)
        }
        closeModal();
    }

    return (
        <div className={classes.listContainer}>
            <div className={classes.header}>
                <h3 className=''> Список сотрудников</h3>
                <button className="btn waves-effect waves-light blue darken-1 btn-small" onClick={() => { clearObject(); setModalActive(true) }}>Зарегистрировать нового</button>
            </div>
            {staff && staff.map((item) => (
                <StaffListItemComp staff={item}
                    key={item.id} updPat={updStaff} />
            ))}
            {!staff || staff.length === 0 &&
                <div>
                    <h3>Не удалось получить список пациентов</h3>
                </div >
            }
            <ModalForm active={modalactive} setActive={setModalActive}>
                <form>
                    <table>
                        <tr>
                            <td>Имя</td>
                            <td><input type="text" name="firstName" onChange={handleChage} value={createDto?.firstName} /></td>
                        </tr>
                        <tr>
                            <td>Фамилия</td>
                            <td><input type="text" name="lastName" onChange={handleChage} value={createDto?.lastName} /></td>
                        </tr>
                        <tr>
                            <td>Отчество</td>
                            <td><input type="text" name="middleName" onChange={handleChage} value={createDto?.middleName} /></td>
                        </tr>
                        <tr>
                            <td>Номер телефона</td>
                            <td><input type="text" name="phoneNumber" onChange={handleChage} value={createDto?.phoneNumber} /></td>
                        </tr>
                        <tr>
                            <td>Дата рождения</td>
                            <td><input type="date" name="birthDate" onChange={handleChage} value={createDto?.birthDate} /></td>
                        </tr>
                        <tr>
                            <td>Должность</td>
                            <td><input type="text" name="position" onChange={handleChage} value={createDto?.position} /></td>
                        </tr>
                        <tr>
                            <td>Рабочих дней в неделю</td>
                            <td><input type="number" max="7" min="0" name="dayWork" id="dayWork" onChange={handleChage} value={createDto?.dayWork} /></td>
                        </tr>
                        <tr>
                            <td>Первый рабочий день</td>
                            <td><input type="date" name="workStart" onChange={handleChage} value={createDto?.workStart} /></td>
                        </tr>
                        <tr>
                            <td>Ставка в час</td>
                            <td><input type="number" step="0.1" name="salaryPerHour" onChange={handleChage} value={createDto?.salaryPerHour} /></td>
                        </tr>
                        <tr>
                            <td colSpan={2}>
                                <button type="button" onClick={CreateStaff}>Добавить</button>
                                <button type="button" onClick={closeModal} >Закрыть</button>
                            </td>
                        </tr>
                    </table>
                </form>
            </ModalForm>
        </div>

    )
}
export default StaffListComp;