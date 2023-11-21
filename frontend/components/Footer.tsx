import React from 'react'
import { CustomButton } from '.'

export const Footer = () => {
  return (
    <div className='footer w-full left-0 bottom-0 h-42 absolute'>
      <nav className='flex justify-between items-center'>
        <div className='flex-col ml-5'>
            <p>Random stuff</p>
            <CustomButton title="idk" btnType="button" containerStyles='font-bold'/>
        </div>
        <div className='flex-col'>
            <p>Company</p>
            <CustomButton title="Careers" btnType="button" containerStyles='font-bold'/>
            <CustomButton title="Privacy policy" btnType="button" containerStyles='font-bold'/>
            <CustomButton title="Terms of service" btnType="button" containerStyles='font-bold'/>
        </div>
        <div className='flex-col'>
            <p>Support</p>
            <CustomButton title="Help" btnType="button" containerStyles='font-bold'/>
            <CustomButton title="Plans & Price" btnType="button" containerStyles='font-bold'/>
            <CustomButton title="Upcoming stuff" btnType="button" containerStyles='font-bold'/>
            
        </div>
        <div className='flex-col mr-5'>
            <p>Follow us</p>
            <CustomButton title="Twitter" btnType="button" containerStyles='font-bold'/>
            <CustomButton title="Instagram" btnType="button" containerStyles='font-bold'/>
            <CustomButton title="Facebook" btnType="button" containerStyles='font-bold'/>
        </div>
        </nav>  

    </div>
  )
}

export default Footer
