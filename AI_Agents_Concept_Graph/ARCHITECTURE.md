# 📐 System Architecture & Subagent Workflow Specifications

## 1. High-Level Architecture Overview

The system operates on an event-driven, graph-centric architecture. Unlike traditional linear agent queues (e.g., Agent A -> Agent B -> Agent C), every agent is a **Node in a Knowledge Graph**.

```
                           +-----------------------------------+
                           |     Obsidian Markdown Vault       |
                           |  (Graph View & Semantic Links)    |
                           +-----------------+-----------------+
                                             |
                                   (Bi-directional Sync)
                                             v
+-----------------------+          +-------------------+          +-----------------------+
|  Gemini 3.6 Engine    |<-------->|  Graph Engine &   |<-------->|   Qwen 3.6 Fast Model  |
|  (Complex Reasoning)  |          |  Event Bus Hub    |          |   (Utility & Format)  |
+-----------------------+          +---------+---------+          +-----------------------+
                                             |
                   +-------------------------+-------------------------+
                   |                         |                         |
                   v                         v                         v
        +--------------------+    +--------------------+    +--------------------+
        | Engineering Cluster|    | Knowledge Cluster  |    | Safety & Guardrails|
        |    (7 Agents)      |    |    (7 Agents)      |    |    (7 Agents)      |
        +--------------------+    +--------------------+    +--------------------+
```

---

## 2. Gemini 3.6 / Qwen 3.6 Hybrid Model Router

To sustain 24/7 continuous operation within strict token budget parameters:
1. **Gemini 3.6 Flash / Pro (Primary Reasoning Core):** Handles complex system architecture, multi-file code synthesis, self-correction, and high-level supervision.
2. **Qwen 3.6 (Fast Utility Engine):** Handles repetitive data formatting, regex extractions, entity linking, and JSON schema verification to save tokens and cut latency.

### Routing Logic Matrix:
* `Task Complexity > 0.7` -> Route to **Gemini 3.6**
* `Structured Formatting / Tagging` -> Route to **Qwen 3.6**
* `Graph Node Link Generation` -> Combined RAG + **Obsidian Bridge**

---

## 3. Obsidian Concept Graph Integration Protocol

The system synchronizes agent states with an **Obsidian Markdown Vault**:
* Every Agent is represented as an Obsidian file: `agents/Agent_35_Supervisor.md`.
* Frontmatter contains live metadata: `status: Active`, `tokens_used_today: 45210`, `linked_nodes: [[Doc_RAG_Core]], [[Task_Backend_Build]]`.
* Obsidian's native **Graph View** displays the real-time operational map of the entire organization.

---

## 4. Subagent Delegation & Task Execution Flow

```
[User Request / System Event]
             │
             ▼
    [01. Master Supervisor Agent]
             │
             ├──► Delegates Code Tasks ─────► [02. Architect Agent] ──► [03. Backend Dev]
             ├──► Delegates Knowledge RAG ──► [15. Graph Listener] ─► [17. Semantic Linker]
             └──► Enforces Budget ──────────► [22. Token Optimizer]
```
