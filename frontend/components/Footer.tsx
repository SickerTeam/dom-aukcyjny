import React from 'react'
import { CustomButton } from '.'

export const Footer = () => {
  return (
    <footer className='footer w-full flex flex-wrap justify-between mt-10 border-t'>
        <div className='flex-col flex ml-5 items-center py-10'>
        <p className='font-bold pb-5'>Random stuff</p>
            <CustomButton title="idk" btnType="button"/>
        </div>
        <div className='flex-col flex items-center py-10'>
        <p className='font-bold pb-5'>Company</p>
            <CustomButton title="Careers" btnType="button"/>
            <CustomButton title="Privacy policy" btnType="button"/>
            <CustomButton title="Terms of service" btnType="button"/>
        </div>
        <div className='flex-col flex items-center py-10'>
        <p className='font-bold pb-5'>Support</p>
            <CustomButton title="Help" btnType="button"/>
            <CustomButton title="Plans & Price" btnType="button"/>
            <CustomButton title="Upcoming stuff" btnType="button"/>
            
        </div>
        <div className='flex-col flex mr-5 items-center py-10'>
            <p className='font-bold pb-5'>Follow us</p>
            <CustomButton title="Twitter" btnType="button"/>
            <CustomButton title="Instagram" btnType="button"/>
            <CustomButton title="Facebook" btnType="button"/>
        </div> 
    </footer>
  )
}

export default Footer
