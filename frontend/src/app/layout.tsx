import './globals.css'
import { Navbar } from '../../components'

export const metadata = {
  title: 'Dom Aukcyjny',
  description: 'Welcome to Zong',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body className="relative">
        <Navbar />
        {children}
      </body>
    </html>
  )
}
