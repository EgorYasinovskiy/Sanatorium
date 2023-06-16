import React, { useState } from 'react'
import classes from "./ModalForm.module.css"
type Props = {
    children : React.ReactNode;
    active : boolean;
    setActive(value:boolean) : void;
}
const ModalForm = (props: Props) => {
  return (
    <div className={!props.active ? classes.modal__outer : classes.modal__outer+" "+classes.active} onClick={()=>props.setActive(false)}>
        <div className={!props.active ? classes.modal__inner : classes.modal__inner+" "+classes.active} onClick={e=>e.stopPropagation()}>
          {props.children}
        </div>
    </div>
  )
}
export default ModalForm;