# 🌌 35 AI Agents Concept Graph & Enterprise Orchestration System

[![Architecture](https://img.shields.io/badge/Architecture-Multi--Agent_Graph-58a6ff?style=for-the-badge&logo=diagramsdotnet)](./ARCHITECTURE.md)
[![Model Engine](https://img.shields.io/badge/Model_Engine-Gemini_3.6_%2F_Qwen_3.6-7928ca?style=for-the-badge&logo=google)](./docs/MODELS.md)
[![Dashboard View](https://img.shields.io/badge/Obsidian-Graph_Dashboard-0070f3?style=for-the-badge&logo=obsidian)](./index.html)
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](./LICENSE)

---

## 📌 Executive Summary

An enterprise-grade **Multi-Agent Orchestration Framework** inspired by continuous 24/7 AI workforce operations. This project visualizes, manages, and executes **35 autonomous AI agents** connected through a **Dynamic Concept Graph (Knowledge Graph)** integrated with **Obsidian Graph View** and Powered by **Gemini 3.6 / Qwen 3.6** reasoning engines.

Instead of isolated linear scripts, this system treats every AI agent, prompt, memory store, and business workflow as an interconnected node in an interactive graph.

---

## 🌟 Key Architectural Highlights

* **🕸️ Obsidian-Integrated Concept Graph:** Live bi-directional synchronization between local Obsidian Markdown Vaults and runtime agent states via WebSocket / Graph Protocol.
* **🧠 Gemini 3.6 & Qwen 3.6 Hybrid Engine:** Intelligent model routing balancing ultra-fast reasoning, low token costs, and high-context processing.
* **🤖 35 Specialized Autonomous Agents:** Organized into 5 core domain clusters (Engineering, Operations, RAG/Knowledge, Quality Control, and Analytics).
* **💸 Token Budget & Cost Guardrails:** Real-time token throttling and cost estimation ensuring continuous 24/7 operations stay within operational budget limits.
* **📊 Interactive Glassmorphism Dashboard:** Live visual monitoring of agent health, node dependencies, event queues, and graph topologies in HTML5/D3.js.

---

## 📐 System Topology & Cluster Taxonomy

```mermaid
graph TD
    subgraph Core ["🧠 Model & Knowledge Core"]
        M1["Gemini 3.6 / Qwen 3.6 Gateway"]
        K1["Obsidian Vault RAG & Concept Graph"]
    end

    subgraph Cluster1 ["💻 Engineering & Dev Cluster (7 Agents)"]
        A1["Architect Agent"]
        A2["Backend Dev Agent"]
        A3["Frontend Dev Agent"]
        A4["Code Reviewer"]
        A5["DevOps & CI/CD"]
        A6["Security Auditor"]
        A7["Database Manager"]
    end

    subgraph Cluster2 ["⚙️ Operations & Automation (7 Agents)"]
        A8["Task Scheduler"]
        A9["Workflow Dispatcher"]
        A10["Data Ingestion"]
        A11["API Gateway Sync"]
        A12["System Health Monitor"]
        A13["Backup & Recovery"]
        A14["Log Synthesizer"]
    end

    subgraph Cluster3 ["📚 Knowledge & RAG Cluster (7 Agents)"]
        A15["Obsidian Graph Listener"]
        A16["Doc Embedder"]
        A17["Semantic Linker"]
        A18["Memory Consolidation"]
        A19["Taxonomy Manager"]
        A20["Entity Extractor"]
        A21["Query Synthesizer"]
    end

    subgraph Cluster4 ["📊 Analytics & Intelligence (7 Agents)"]
        A22["Token Usage Optimizer"]
        A23["Cost Tracker"]
        A24["Performance Metrics"]
        A25["Trend Analyzer"]
        A26["Reporting Agent"]
        A27["Anomaly Detector"]
        A28["Efficiency Evaluator"]
    end

    subgraph Cluster5 ["🛡️ Quality & Safety (7 Agents)"]
        A29["Output Guardrail"]
        A30["Schema Validator"]
        A31["Fact Checker"]
        A32["Privacy Masker"]
        A33["Compliance Checker"]
        A34["Self-Correction Agent"]
        A35["Master Supervisor Agent"]
    end

    Core <--> Cluster1
    Core <--> Cluster2
    Core <--> Cluster3
    Core <--> Cluster4
    Core <--> Cluster5
```

---

## 🛠️ Tech Stack

| Layer | Technology |
| :--- | :--- |
| **Model Engine** | Gemini 3.6 Flash / Qwen 3.6 / Multi-LLM Router |
| **Graph Visualization** | Obsidian Graph View (Native) & D3.js / Canvas Web Dashboard |
| **State & Memory** | Vector Database (Chroma / Qdrant) + Obsidian Markdown Vault |
| **Orchestration** | Python / Node.js Multi-Agent Loop + WebSockets |
| **Security & Privacy** | Local PII Masking, Token Rate Limiters |

---

## 🚀 Quick Start & Interactive Dashboard

To launch the interactive Graph Dashboard & Implementation Plan:
1. Open [`index.html`](./index.html) in your browser.
2. Drag and explore the 35 AI agent nodes, inspect live dependencies, and view execution metrics.

---

## 📜 Documentation Links

- [📐 Detailed Architecture & Communication Protocols](./ARCHITECTURE.md)
- [🤖 Full 35-Agent Catalog & Subagent Workflows](./AGENTS_TAXONOMY.md)
- [🌐 Interactive HTML Dashboard](./index.html)
