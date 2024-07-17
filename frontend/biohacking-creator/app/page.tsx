
import Link from "next/link";



export default async function Home() {
  return (
    <main className="flex flex-col items-center justify-between p-50">
      <ul>
        <li>
          <Link href="/basic"><button className="btn btn-primary mb-10">Basic Example</button></Link>
        </li>
        <li>
          <Link href="/jwt-cookie"><button className="btn btn-primary mb-10">JWT Cookie</button></Link>
        </li>
        <li>
          <Link href="/connect-button"><button className="btn btn-primary mb-10">Connect Button Integration</button></Link>
        </li>
      </ul>
    </main>
  );
}
