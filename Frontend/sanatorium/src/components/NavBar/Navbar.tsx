import React from 'react'
import { Link } from 'react-router-dom'

type Props = {}

const Navbar = () => {
    return (
        <nav>
            <div className="nav-wrapper blue darken-1">
                <Link to="/" className="brand-logo">Мой санаторий</Link>
                <ul id="nav-mobile" className="right hide-on-med-and-down">
                    <li><Link to="/patients" >Пациенты</Link></li>
                    <li><Link to="/staff" >Сотрудники</Link></li>
                    <li><Link to="/room" >Номерной фонд</Link></li>
                    <li><Link to="/" >Инвентаризация</Link></li>
                    <li><Link to="/" >Мед-карты</Link></li>
                    <li><Link to="/" >Назначенные процедуры</Link></li>
                </ul>
            </div>
        </nav>
    )
}
export default Navbar;