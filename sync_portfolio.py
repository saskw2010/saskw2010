import os, requests, base64

GITHUB_USER = os.environ.get("GITHUB_USER", "saskw2010")
GH_PAT = os.environ.get("GH_PAT")

HEADERS = {
    "Accept": "application/vnd.github.v3+json"
}
if GH_PAT:
    HEADERS["Authorization"] = f"token {GH_PAT}"

def fetch_all_repos():
    repos = []
    page = 1
    while True:
        url = f"https://api.github.com/user/repos?per_page=100&page={page}"
        print(f"Fetching page {page}...")
        r = requests.get(url, headers=HEADERS)
        if r.status_code != 200:
            print(f"Error fetching repos: {r.text}")
            break
        data = r.json()
        if not data:
            break
        repos.extend(data)
        page += 1
    return repos

def build_portfolio():
    print("Starting Portfolio Build Process...")
    repos = fetch_all_repos()
    print(f"Fetched {len(repos)} repositories.")

    # Sort repos by primary language to group them
    # Filter out empty or fully archived non-relevant repos if needed, but the user wanted all 500
    langs = {}
    for r in repos:
        lang = r.get('language') or 'Other'
        if lang not in langs:
            langs[lang] = []
        langs[lang].append(r)

    # Read CV if it exists locally
    cv_text = ""
    if os.path.exists("CV.md"):
        with open("CV.md", "r", encoding="utf-8") as f:
            cv_text = f.read()
    else:
        cv_text = "### 👨‍💻 Full-Stack Developer\nWelcome to my portfolio! Here you will find an auto-generated showcase of all my projects."

    # Build the Markdown content
    md = []
    md.append(f"# Hi there 👋, I am {GITHUB_USER}\n")
    md.append(cv_text)
    md.append("\n---\n")
    md.append("## 📁 Auto-Generated Portfolio (Synced from Private & Public Repos)\n")
    md.append("> *This section is automatically updated daily to reflect my latest work across all my repositories.*\n\n")

    # Generate a table of contents / categories
    md.append("### 🗂️ Categories\n")
    for lang in sorted(langs.keys()):
        count = len(langs[lang])
        anchor = lang.lower().replace(" ", "-").replace("+", "")
        md.append(f"- [{lang} ({count} projects)](#{anchor})")
    md.append("\n---\n")

    # Generate the projects lists
    for lang in sorted(langs.keys()):
        md.append(f"### {lang}")
        md.append("<details><summary>Click to view projects</summary>\n")
        
        # Sort projects by recent updates
        projects = sorted(langs[lang], key=lambda x: x.get('updated_at', ''), reverse=True)
        
        for p in projects:
            name = p.get('name', 'Unknown')
            desc = p.get('description', '') or 'No description provided.'
            url = p.get('html_url', '#')
            is_private = p.get('private', False)
            visibility = "🔒 Private" if is_private else "🌍 Public"
            
            md.append(f"#### [{name}]({url}) - `{visibility}`")
            md.append(f"> {desc}\n")
            
        md.append("</details>\n")
        md.append("\n---\n")

    # Write to README.md
    with open("README.md", "w", encoding="utf-8") as f:
        f.write("\n".join(md))
        
    print("Portfolio README.md generated successfully!")

if __name__ == "__main__":
    build_portfolio()
