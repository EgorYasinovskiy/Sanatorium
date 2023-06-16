import React, { useContext, useEffect, useState } from 'react'
import ApiContext from '../ApiContext'
import { RoomDTO, RoomListDTO, UpdateRoomDTO } from '../APIServices/RoomServiceDataContract';
import ModalForm from '../components/ModalForm/ModalForm';

type Props = {}

const RoomsPage = (props: Props) => {
    const apictx = useContext(ApiContext);
    const [rooms, setRooms] = useState<RoomListDTO>()
    const [loading, setLoading] = useState(true);
    const [active, setActive] = useState(false);
    const [editRoom, setEditRoom] = useState<RoomDTO>();
    const [updDateRoom, setUpdRoom] = useState<UpdateRoomDTO>();
    useEffect(() => {
        const fetchData = async () => {
            try {
                setLoading(true);
                var response = await apictx?.Room.roomsGet()
                if (response?.ok) {
                    setRooms(response.data);
                }
                setLoading(false)
            }
            catch (err) {
                setLoading(false);
                console.log(err);
            }
        }
        fetchData();
    }, [])
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        console.log("upd " + e.target.value)
        console.log(updDateRoom)
        setUpdRoom({
            ...updDateRoom, [e.target.name]: Number(e.target.value)
        })
        console.log(updDateRoom)

    }
    return (
        <div>
            {loading ? <h2 className="center"> Data loading</h2> : (!rooms?.rooms?.length ? <h2 className="center">Ошибка при получении данных</h2> :
                <table>
                    <thead>
                        <tr>
                            <th>Номер комнаты</th>
                            <th>Категория комнаты</th>
                            <th>Количество коек</th>
                            <th>Статус</th>
                            <th>Цена за день</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rooms.rooms.map((item) => (
                            <tr key={item.id}>
                                <td>{item.roomNumber}</td>
                                <td>{item.category}</td>
                                <td>{item.bedsCount}</td>
                                <td>{item.isFree ? "Свободна" : "Занята"}</td>
                                <td>{item.costPerDay}</td>
                                <td>
                                    <button
                                        className={"btn waves-effect waves-light blue darken-1 btn-small"}
                                        type="button"
                                        onClick={() => { setActive(true); setEditRoom(item); setUpdRoom({ id: item.id, costPerDay: item.costPerDay, category: item.category, roomNumber: item.roomNumber, bedsCount: item.bedsCount }) }}>
                                        <i className="material-icons">edit</i>
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>)}
            <ModalForm active={active} setActive={setActive}>
                <form>
                    <table className='striped'>
                        <tbody>
                            <tr>
                                <td>Номер</td>
                                <td><input type="number" name="roomNumber" value={updDateRoom?.roomNumber} onChange={handleChange} /></td>
                            </tr>
                            <tr>
                                <td>Категория</td>
                                <td><input type="number" name="category" value={updDateRoom?.category} onChange={handleChange} /></td>
                            </tr>
                            <tr>
                                <td>Цена</td>
                                <td><input type="number" name="costPerDay" value={updDateRoom?.costPerDay} onChange={handleChange} /></td>
                            </tr>
                            <tr>
                                <td>Количество кроватей</td>
                                <td><input type="number" name="bedsCount" value={updDateRoom?.bedsCount} onChange={handleChange} /></td>
                            </tr>
                            <tr>
                                <td><button
                                    className={"btn waves-effect waves-light blue darken-1 btn-small"}
                                    type="button"
                                    onClick={async () => {
                                        try {
                                            var response = await apictx?.Room.roomsUpdate(updDateRoom!);
                                            var newRooms = await apictx?.Room.roomsGet();
                                            setActive(false);
                                            if(newRooms?.ok)
                                            {
                                                setRooms(newRooms.data);
                                            }
                                        }
                                        catch(err)
                                        {console.log(err)}
                                        
                                    }}>
                                    Сохранить
                                </button></td>
                                <td><button
                                    className={"btn waves-effect waves-light blue darken-1 btn-small"}
                                    type="button">
                                    Закрыть
                                </button></td>
                            </tr>
                        </tbody>
                    </table>
                </form>
            </ModalForm>
        </div >
    )
}
export default RoomsPage;